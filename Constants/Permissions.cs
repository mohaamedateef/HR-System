namespace HRSystem.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.View",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
            };
        }
        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();
            var modules = Enum.GetValues(typeof(Modules));
            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));
            return allPermissions; 
        }
        public static class Employee
        {
            public const string View = "Permissions.employee.View";
            public const string Create = "Permissions.employee.Create";
            public const string Edit = "Permissions.employee.Edit";
            public const string Delete = "Permissions.employee.Delete";
        }
        public static class Salary
        {
            public const string View = "Permissions.salaryReport.View";
            public const string Create = "Permissions.salaryReport.Create";
            public const string Edit = "Permissions.salaryReport.Edit";
            public const string Delete = "Permissions.salaryReport.Delete";
        }
        public static class NewGroup
        {
            public const string View = "Permissions.group.View";
            public const string Create = "Permissions.group.Create";
            public const string Edit = "Permissions.group.Edit";
            public const string Delete = "Permissions.group.Delete";
        }
        public static class progress
        {
            public const string View = "Permissions.progress.View";
            public const string Create = "Permissions.progress.Create";
            public const string Edit = "Permissions.progress.Edit";
            public const string Delete = "Permissions.progress.Delete";
        }
        public static class generalSetting
        {
            public const string View = "Permissions.generalSetting.View";
            public const string Create = "Permissions.generalSetting.Create";
            public const string Edit = "Permissions.generalSetting.Edit";
            public const string Delete = "Permissions.generalSetting.Delete";
        }
        public static class permissions
        {
            public const string View = "Permissions.permissions.View";
            public const string Create = "Permissions.permissions.Create";
            public const string Edit = "Permissions.permissions.Edit";
            public const string Delete = "Permissions.permissions.Delete";
        }
        public static class attendance
        {
            public const string View = "Permissions.attendance.View";
            public const string Create = "Permissions.attendance.Create";
            public const string Edit = "Permissions.attendance.Edit";
            public const string Delete = "Permissions.attendance.Delete";
        }
    }
}
