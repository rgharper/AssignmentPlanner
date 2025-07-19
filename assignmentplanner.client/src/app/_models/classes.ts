// AssignmentPlanner - Classes model definitions
export class Assignment {
  id: Number;
  title: string;
  description?: string;
  dueDate: Date;
  classId: Number;
  completed: boolean;
  constructor(id: Number, title: string, dueDate: Date, classId:Number, description?: string, completed: boolean = false) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.dueDate = dueDate;
    this.classId = classId;
    this.completed = completed;
  }
}
export class Class {
  id?: Number;
  name: string;
  assignments: Assignment[];
  constructor(name: string, id?: Number, assignments?: Assignment[]) {
    this.id = id;
    this.name = name;
    this.assignments = assignments || [];
  }
}
