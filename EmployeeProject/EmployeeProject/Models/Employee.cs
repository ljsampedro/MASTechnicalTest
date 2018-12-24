using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{

    public abstract class Employee
    {
        public abstract int id  { get; } 
        public abstract string name  { get; }
        public abstract string contractTypeName { get; }
        public abstract int roleId { get; }
        public abstract string roleName { get; }
        public abstract string roleDescription { get; }
        public abstract int hourlySalary { get; }
        public abstract int monthlySalary { get; }

        public abstract int annualSalary { get; }

        public abstract int  CalculateAnnualSalary();
    }

    public class HourlySalaryEmployee : Employee
    {

        private int _id;
        private readonly string _name;
        private string _contractTypeName;
        private int _roleId;
        private string _roleName;
        private string _roleDescription;
        private int _hourlySalary;
        private int _monthlySalary;

        private int _annualSalary;

        public HourlySalaryEmployee(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, int hourlySalary, int monthlySalary)
        {
            _id = id;
             _name = name;
             _contractTypeName = contractTypeName;
             _roleId = roleId;
             _roleName = roleName;
             _roleDescription = roleDescription;
             _hourlySalary = hourlySalary;
             _monthlySalary = monthlySalary;
             _annualSalary = 120 * hourlySalary * 12;
        }

        public override int id
        {
            get { return _id; }
        }

        public override string name
        {
            get { return _name; }
        }

        public override string contractTypeName
        {
            get { return _contractTypeName; }
        }

        public override int roleId
        {
            get { return _roleId; }
        }

        public override string roleName
        {
            get { return _roleName; }
        }

        public override string roleDescription
        {
            get { return _roleDescription; }
        }

        public override int monthlySalary
        {
            get { return _monthlySalary; }
        }

        public override int hourlySalary
        {
            get { return _hourlySalary; }
        }

        public override int annualSalary
        {
            get { return _annualSalary; }
        }

        public override int CalculateAnnualSalary()
        {
            return 120 * hourlySalary * 12;
        }
    }

    public class MonthlySalaryEmployee : Employee
    {

        private int _id;
        private readonly string _name;
        private string _contractTypeName;
        private int _roleId;
        private string _roleName;
        private string _roleDescription;
        private int _hourlySalary;
        private int _monthlySalary;

        private int _annualSalary;

        public MonthlySalaryEmployee(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, int hourlySalary, int monthlySalary)
        {
            _id = id;
            _name = name;
            _contractTypeName = contractTypeName;
            _roleId = roleId;
            _roleName = roleName;
            _roleDescription = roleDescription;
            _hourlySalary = hourlySalary;
            _monthlySalary = monthlySalary;
            _annualSalary = monthlySalary * 12;
        }

        public override int id
        {
            get { return _id; }
        }

        public override string name
        {
            get { return _name; }
        }

        public override string contractTypeName
        {
            get { return _contractTypeName; }
        }

        public override int roleId
        {
            get { return _roleId; }
        }

        public override string roleName
        {
            get { return _roleName; }
        }

        public override string roleDescription
        {
            get { return _roleDescription; }
        }

        public override int monthlySalary
        {
            get { return _monthlySalary; }
        }

        public override int hourlySalary
        {
            get { return _hourlySalary; }
        }

        public override int annualSalary
        {
            get { return _annualSalary; }
        }

        public override int CalculateAnnualSalary()
        {
            return _monthlySalary * 12;
        }
    }


    public abstract class Factory
    {
        public abstract Employee FactoryMethod(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, int hourlySalary, int monthlySalary);
    }

    public class FactoryImplementation : Factory
    {
        public override Employee FactoryMethod(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, int hourlySalary, int monthlySalary)
        {
            switch (contractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new HourlySalaryEmployee(id, name,  contractTypeName,  roleId,  roleName,  roleDescription,  hourlySalary,  monthlySalary);
                case "MonthlySalaryEmployee":
                    return new MonthlySalaryEmployee(id, name, contractTypeName, roleId, roleName, roleDescription, hourlySalary, monthlySalary);
                default:
                    return new MonthlySalaryEmployee(id, name, contractTypeName, roleId, roleName, roleDescription, hourlySalary, monthlySalary);
            }
        }
    }

    public enum ContractType
    {
        HOURLYSALARYEMPLOYEE,
        MONTHLYSALARYEMPLOYEE
    }
}