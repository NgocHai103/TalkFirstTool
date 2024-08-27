public class Configuration
{
    public int Slot { get; set; }
    public Manager Manager { get; set; }
    public Student Student { get; set; }
    public Teacher Teacher { get; set; }
    public List<SubClass> SubClass { get; set; }
    public TimeSchedule TimeSchedule { get; set; }
}

public class Manager
{
    public Register Create { get; set; }
    public Register Update { get; set; }
}

public class Register
{
    public Time Time { get; set; }
    public string Type { get; set; }
    public int Number { get; set; }
    public RegisterList RegisterList { get; set; }
}

public class Time
{
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }
}

public class RegisterList
{
    public Time Time { get; set; }
    public string Type { get; set; }
    public bool UseTime { get; set; }
    public string TypeCompare { get; set; }
    public int TimeTypeActive { get; set; }
    public int ActiveDayOfWeek { get; set; }
    public bool UseActiveDayOfWeek { get; set; }
}

public class Student
{
    public Register Cancel { get; set; }
    public Register Register { get; set; }
}

public class Teacher
{
    public Register Cancel { get; set; }
    public Register Register { get; set; }
}

public class SubClass
{
    public string Id { get; set; }
    public string Key { get; set; }
    public string Label { get; set; }
}

public class TimeSchedule
{
    public Manager Manager { get; set; }
}

public class Level
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Label { get; set; }
    public Configuration Configuration { get; set; }
    public string GetGroup { get; set; }
}

public class ClassModel
{
    public ClassType TimeDuration { get; set; }
    public ClassType ClassType { get; set; }
    public SubClass SubClass { get; set; }
    public List<Level> Level { get; set; }
    public object StudentDocumentLink { get; set; }
    public Guid Id { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int Slot { get; set; }
    public int SlotUsed { get; set; }
    public SyllabusId SyllabusId { get; set; }
    public LessonStatus LessonStatus { get; set; }
    public ClassTimeId ClassTimeId { get; set; }
    public Room Room { get; set; }
    public TeacherId TeacherId { get; set; }
    public DateTime TimeScheduleStart { get; set; }
    public DateTime TimeScheduleEnd { get; set; }
    public string LessonStatusProcess { get; set; }
    public LessonProcess LessonProcess { get; set; }
    public DateTime TimeSchedule { get; set; }

    public bool IsRegistried { get; set; }
}

public class ClassType
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Label { get; set; }
    public Configuration Configuration { get; set; }
    public string GetGroup { get; set; }
}

public class SyllabusId
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Label { get; set; }
    public object Configuration { get; set; }
    public string GetGroup { get; set; }
}

public class LessonStatus
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Label { get; set; }
    public Configuration Configuration { get; set; }
    public string GetGroup { get; set; }
}

public class ClassTimeId
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Label { get; set; }
    public Configuration Configuration { get; set; }
    public string GetGroup { get; set; }
}

public class Room
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Label { get; set; }
    public Configuration1 Configuration { get; set; }
    public string GetGroup { get; set; }
}

public class Configuration1
{
    public string color { get; set; }
}

public class TeacherId
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Image { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public string Label { get; set; }
}

public class LessonProcess
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Label { get; set; }
    public Configuration Configuration { get; set; }
    public string GetGroup { get; set; }
}
