import { Component, OnInit } from '@angular/core';
import {TaskService} from './Services/task.service';
import {Task} from './Models/task';
import { NgForm } from '@angular/forms';
import { stringify } from 'querystring';
import { ConvertActionBindingResult } from '@angular/compiler/src/compiler_util/expression_converter';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'ThinkTestWeb';

  task = {} as Task;
  tasks: Task[];
  isDone : string;

  constructor(private taskService: TaskService) {}
  
  ngOnInit() {
    this.getTasks();
  }

    saveTask(form: NgForm) {
      //this.isDone = this.task.isDone;
      if (this.isDone == "yes" ){
          this.task.isDone = true;
      }else{
          this.task.isDone = false;
      }

      console.log(this.task);
      if (this.task.id !== undefined) {
        this.taskService.updateTask(this.task).subscribe(() => {
          this.cleanForm(form);
        });
      } else {
        this.task.id = 0;
        this.taskService.createTask(this.task).subscribe(() => {
          this.cleanForm(form);
        });
      }
    }
  
    getTasks() {
      this.taskService.getTasks().subscribe((tasks: Task[]) => {
        this.tasks = tasks;
      });
    }
  
    deleteTask(task: Task) {
      this.taskService.deleteTask(task).subscribe(() => {
        this.getTasks();
      });
    }
  
    editTask(task: Task) {
      this.task = { ...task };
      if (this.task.isDone == true){
        this.isDone = "yes";
      }else{
        this.isDone = "no";
      }
    }
  
    cleanForm(form: NgForm) {
      this.getTasks();
      form.resetForm();
      this.task = {} as Task;
    }
}
