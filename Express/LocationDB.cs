﻿using System.Data.SqlClient;

class LocationDB
{
    DBConnection connection;
    SqlCommand command;

    public LocationDB()
    {
        connection = new DBConnection();
    }

    public void insertNewLocation(Location location)
    {
        connection.open();
        command = new SqlCommand("insert into Location(name,address,startDate,endDate,workHours,securityNumbers,supervisorNumbers,managerNumbers) values('" + location.getName() + "' , '" + location.getAddress() + "' , '" + location.getStartDate() + "' , '" + location.getEndDate() + "' , '" + location.getWorkHours() + "' , '" + location.getSecurityNumbers() + "' , '" + location.getSupervisorNumbers() + "' , '" + location.getManagerNumbers() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void updateLocation(Location location)
    {
        connection.open();
        command = new SqlCommand("update Location set securitySalary='" + location.getSecuritySalary() + "' , aupervisorSalary='" + location.getSupervisorSalary() + "' , managerSalary='" + location.getManagerSalary() + "' where name='" + location.getName() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void updateLocationInformation(Location location)
    {
        connection.open();
        command = new SqlCommand("update Location set name = '" + location.getName() + "',address='" + location.getAddress() + "',startDate='" + location.getStartDate() + "',endDate='" + location.getEndDate() + "',workHours='" + location.getWorkHours() + "',securityNumbers='" + location.getSecurityNumbers() + "',supervisorNumbers='" + location.getSupervisorNumbers() + "',managerNumbers='" + location.getManagerNumbers() + "' where ID='" + location.getID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void selectSecurityNumbers(Location location)
    {
        connection.open();
        command = new SqlCommand("select securityNumbers from Location where ID='" + location.getID() + "' or name='" + location.getName() + "'", connection.getConnection());
        location.setSecurityNumbers((int)command.ExecuteScalar());
        connection.close();
    }

    public void selectSupervisorNumbers(Location location)
    {
        connection.open();
        command = new SqlCommand("select supervisorNumbers from Location where ID='" + location.getID() + "' or name='" + location.getName() + "'", connection.getConnection());
        location.setSupervisorNumbers((int)command.ExecuteScalar());
        connection.close();
    }

    public void selectManagerNumbers(Location location)
    {
        connection.open();
        command = new SqlCommand("select managerNumbers from Location where ID='" + location.getID() + "' or name='" + location.getName() + "'", connection.getConnection());
        location.setManagerNumbers((int)command.ExecuteScalar());
        connection.close();
    }

    public void selectSecuritySalary(Location location)
    {
        connection.open();
        command = new SqlCommand("select securitySalary from Location where name='" + location.getName() + "'", connection.getConnection());
        location.setSecuritySalary((double)command.ExecuteScalar());
        connection.close();
    }

    public void selectSupervisorSalary(Location location)
    {
        connection.open();
        command = new SqlCommand("select aupervisorSalary from Location where name='" + location.getName() + "'", connection.getConnection());
        location.setSupervisorSalary((double)command.ExecuteScalar());
        connection.close();
    }

    public void selectManagerSalary(Location location)
    {
        connection.open();
        command = new SqlCommand("select managerSalary from Location where name='" + location.getName() + "'", connection.getConnection());
        location.setManagerSalary((double)command.ExecuteScalar());
        connection.close();
    }

    public void selectLocationIDbyName(Location location)
    {
        connection.open();
        command = new SqlCommand("select ID from Location where name='" + location.getName() + "'", connection.getConnection());
        location.setID((int)command.ExecuteScalar());
        connection.close();
    }

    public SqlDataReader fillComboboxLocationName()
    {
        connection.open();
        command = new SqlCommand("select * from Location", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public SqlDataReader fillComboboxLocationNameReaday()
    {
        connection.open();
        command = new SqlCommand("select * from Location where securitySalary is not null and aupervisorSalary is not null and managerSalary is not null", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public void selectAddress(Location location)
    {
        connection.open();
        command = new SqlCommand("select address from Location where name='" + location.getName() + "'", connection.getConnection());
        location.setAddress(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectStartDate(Location location)
    {
        connection.open();
        command = new SqlCommand("select startDate from Location where name='" + location.getName() + "'", connection.getConnection());
        location.setStartDate(command.ExecuteScalar().ToString());
        connection.close();
    }

    public void selectEndDate(Location location)
    {
        connection.open();
        command = new SqlCommand("select endDate from Location where name='" + location.getName() + "'", connection.getConnection());
        location.setEndDate(command.ExecuteScalar().ToString());
        connection.close();
    }

    public void selectWorkHours(Location location)
    {
        connection.open();
        command = new SqlCommand("select workHours from Location where name='" + location.getName() + "'", connection.getConnection());
        location.setWorkHours((int)command.ExecuteScalar());
        connection.close();
    }

    public void selectLocationName(Location location)
    {
        connection.open();
        command = new SqlCommand("select name from Location where ID='" + location.getID() + "'", connection.getConnection());
        location.setName(command.ExecuteScalar() as string);
        connection.close();
    }

    public SqlDataAdapter fillDataGridViewLocationAttendance(Location location)
    {
        connection.open();
        string query = "select Employee.ID,Employee.name,AttendanceContent.d1,AttendanceContent.d2,AttendanceContent.d3,AttendanceContent.d4,AttendanceContent.d5,AttendanceContent.d6,AttendanceContent.d7,AttendanceContent.d8,AttendanceContent.d9,AttendanceContent.d10,AttendanceContent.d11,AttendanceContent.d12,AttendanceContent.d13,AttendanceContent.d14,AttendanceContent.d15,AttendanceContent.d16,AttendanceContent.d17,AttendanceContent.d18,AttendanceContent.d19,AttendanceContent.d20,AttendanceContent.d21,AttendanceContent.d22,AttendanceContent.d23,AttendanceContent.d24,AttendanceContent.d25,AttendanceContent.d26,AttendanceContent.d27,AttendanceContent.d28,AttendanceContent.d29,AttendanceContent.d30,AttendanceContent.d31" +
            " from Employee" +
            " left join AttendanceContent" +
            " on Employee.ID = AttendanceContent.empID" +
            " where locationID='" + location.getID()+ "'";
        command = new SqlCommand(query, connection.getConnection());
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        return adapter;
    }
}
