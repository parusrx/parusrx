// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a template key enumeration.
/// </summary>
public enum TemplateKey
{
    /// <summary>
    /// The approver and HR.
    /// </summary>
    [XmlEnum("APPROVER_AND_HR")]
    APPROVER_AND_HR,

    /// <summary>
    /// The only HR.
    /// </summary>
    [XmlEnum("ONLY_HR")]
    ONLY_HR,

    /// <summary>
    /// The two HR and approver.
    /// </summary>
    [XmlEnum("TWO_HR_AND_APPROVER")]
    TWO_HR_AND_APPROVER,

    /// <summary>
    /// The two approver and HR.
    /// </summary>
    [XmlEnum("TWO_APPROVER_AND_HR")]
    TWO_APPROVER_AND_HR,

    /// <summary>
    /// The employee functional head, manager, and HR.
    /// </summary>
    [XmlEnum("EMPLOYEE_FUNCTIONAL_HEAD_MANAGER_AND_HR")]
    EMPLOYEE_FUNCTIONAL_HEAD_MANAGER_AND_HR,

    /// <summary>
    /// The employee department head, manager, and HR.
    /// </summary>
    [XmlEnum("EMPLOYEE_DEPARTMENT_HEAD_MANAGER_AND_HR")]
    EMPLOYEE_DEPARTMENT_HEAD_MANAGER_AND_HR,

    /// <summary>
    /// The employee functional head, manager, department head, manager, and HR.
    /// </summary>
    [XmlEnum("EMPLOYEE_FUNCTIONAL_HEAD_MANAGER_DEPARTMENT_HEAD_MANAGER_AND_HR")]
    EMPLOYEE_FUNCTIONAL_HEAD_MANAGER_DEPARTMENT_HEAD_MANAGER_AND_HR,

    /// <summary>
    /// The employee department head, manager, functional head, manager, and HR.
    /// </summary>
    [XmlEnum("EMPLOYEE_DEPARTMENT_HEAD_MANAGER_FUNCTIONAL_HEAD_MANAGER_AND_HR")]
    EMPLOYEE_DEPARTMENT_HEAD_MANAGER_FUNCTIONAL_HEAD_MANAGER_AND_HR,

    /// <summary>
    /// The employee department head manager and his department head manager and HR.
    /// </summary>
    [XmlEnum("EMPLOYEE_DEPARTMENT_HEAD_MANAGER_AND_HIS_DEPARTMENT_HEAD_MANAGER_AND_HR")]
    EMPLOYEE_DEPARTMENT_HEAD_MANAGER_AND_HIS_DEPARTMENT_HEAD_MANAGER_AND_HR,

    /// <summary>
    /// The HR and employee department head manager and HR.
    /// </summary>
    [XmlEnum("HR_AND_EMPLOYEE_DEPARTMENT_HEAD_MANAGER_AND_HR")]
    HR_AND_EMPLOYEE_DEPARTMENT_HEAD_MANAGER_AND_HR,,

    /// <summary>
    /// The employee and head manager and additional four head manager and HR.
    /// </summary>
    [XmlEnum("EMPLOYEE_AND_HEAD_MANAGER_AND_ADDITIONAL_FOUR_HEAD_MANAGER_AND_HR")]
    EMPLOYEE_AND_HEAD_MANAGER_AND_ADDITIONAL_FOUR_HEAD_MANAGER_AND_HR,

    /// <summary>
    /// The employee and additional four employees and HR.
    /// </summary>
    [XmlEnum("EMPLOYEE_ADDITIONAL_FOUR_EMPLOYEES_AND_HR")]
    EMPLOYEE_ADDITIONAL_FOUR_EMPLOYEES_AND_HR,

    /// <summary>
    /// The manager first.
    /// </summary>
    [XmlEnum("MANAGER_FIRST")]
    MANAGER_FIRST,

    /// <summary>
    /// The employee first.
    /// </summary>
    [XmlEnum("EMPLOYEE_FIRST")]
    EMPLOYEE_FIRST,

    /// <summary>
    /// The employee only.
    /// </summary>
    [XmlEnum("EMPLOYEE_ONLY")]
    EMPLOYEE_ONLY,

    /// <summary>
    /// The manager only.
    /// </summary>
    [XmlEnum("MANAGER_ONLY")]
    MANAGER_ONLY,

    /// <summary>
    /// The route.
    /// </summary>
    [XmlEnum("ROUTE")]
    ROUTE
}
