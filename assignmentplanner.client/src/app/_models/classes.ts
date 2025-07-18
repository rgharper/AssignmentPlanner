// AssignmentPlanner - Classes model definitions
export class Assignment {
  id: string;
  title: string;
  description?: string;
  dueDate: Date;
  classId: string;
  completed: boolean;
  constructor(id: string, title: string, dueDate: Date, classId: string, description?: string, completed: boolean = false) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.dueDate = dueDate;
    this.classId = classId;
    this.completed = completed;
  }
}
export class Class {
  id: string;
  name: string;
  assignments: Assignment[];
  constructor(id: string, name: string, assignments?: Assignment[]) {
    this.id = id;
    this.name = name;
    this.assignments = assignments || [];
  }
  generateAssignments():void {
    for (let i = 0; i < 5; i++) {
      this.assignments.push(new Assignment(i.toString(), `Assignment${i}`, new Date(Date.now()+i*86400000), this.id, `An assignment ${i}`));
    }
  }
}
