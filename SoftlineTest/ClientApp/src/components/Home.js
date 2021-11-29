import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = { employees: [], loading: true };
    this.onClick = this.onClick.bind(this);
  }
  
  onClick(e){
      this.props.onRemove(this.state.data);
  }

  componentDidMount() {
    this.employeeData();
  }

  static renderEmployeeTable(employees) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>ФИО</th>
            <th>Должность</th>
            <th>Год рождения</th>
            <th>Характеристика</th>
            <th>Декрет</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {employees.map(employee =>
            <tr key={employee.id}>
              <td>{employee.name}</td>
              <td>{employee.position}</td>
              <td>{employee.year}</td>
              <td>{employee.characteristic}</td>
              <td>{employee.decree}</td>
              <td className="btn btn-danger" onClick={this.onClick}>Удалить</td> 
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Загрузка...</em></p>
      : Home.renderEmployeeTable(this.state.employees);

    return (
      <div>
        <h1 id="tabelLabel" >Сотрудники</h1>
        {contents}
      </div>
    );
  }

  async employeeData() {
    const response = await fetch('api/getEmployee');
    const data = await response.json();
    this.setState({ employees: data, loading: false });
  }
}

class EmployeeForm extends React.Component{
 
  constructor(props){
      super(props);
      this.state = {name: "", price:0};

      this.onSubmit = this.onSubmit.bind(this);
      this.onNameChange = this.onNameChange.bind(this);
      this.onPriceChange = this.onPriceChange.bind(this);
  }
  onNameChange(e) {
      this.setState({name: e.target.value});
  }
  onPriceChange(e) {
      this.setState({price: e.target.value});
  }
  onSubmit(e) {
      e.preventDefault();
      var employeeName = this.state.name.trim();
      var employeePosition = this.state.position.trim();
      var employeeYear = this.state.year;
      var employeeCharacteristic = this.state.characteristic.trim();
      var employeeDecree = this.state.decree;
      this.props.onEmployeeSubmit({ name: employeeName, position: employeePosition, year: employeeYear, 
        characteristic: employeeCharacteristic, decree: employeeDecree});
  }
  render() {
      return (
        <form onSubmit={this.onSubmit}>
          <input type="submit" value="Сохранить" />
        </form>
      );
  }
}


class EmployeeList extends React.Component{

  constructor(props){
      super(props);
      this.state = { employees: [] };

      this.onAddEmployee = this.onAddEmployee.bind(this);
      this.onRemoveEmployee = this.onRemoveEmployee.bind(this);
  }
  // загрузка данных
  loadData() {
      var xhr = new XMLHttpRequest();
      xhr.open("get", this.props.apiUrl, true);
      xhr.onload = function () {
          var data = JSON.parse(xhr.responseText);
          this.setState({ employees: data });
      }.bind(this);
      xhr.send();
  }
  componentDidMount() {
      this.loadData();
  }
  // добавление объекта
  onAddEmployee(employee) {
      if (employee) {

          const data = new FormData();
          data.append("name", employee.name);
          data.append("position", employee.position);
          data.append("year", employee.year);
          data.append("characteristic", employee.characteristic);
          data.append("decree", employee.decree);
          var xhr = new XMLHttpRequest();

          xhr.open("post", this.props.apiUrl, true);
          xhr.onload = function () {
              if (xhr.status === 200) {
                  this.loadData();
              }
          }.bind(this);
          xhr.send(data);
      }
  }
  // удаление объекта
  onRemoveEmployee(employee) {

      if (employee) {
          var url = this.props.apiUrl + "/" + employee.id;
           
          var xhr = new XMLHttpRequest();
          xhr.open("delete", url, true);
          xhr.setRequestHeader("Content-Type", "application/json");
          xhr.onload = function () {
              if (xhr.status === 200) {
                  this.loadData();
              }
          }.bind(this);
          xhr.send();
      }
  }
  render(){

      var remove = this.onRemoveEmployee;
      return <div>
              <EmployeeForm onEmployeeSubmit={this.onAddEmployee} />
              <div>
                  {
                  this.state.employee.map(function(employee){
                   
                  return <Employee key={employee.id} employee={employee} onRemove={remove} />
                  })
                  }
              </div>
      </div>;
  }
}