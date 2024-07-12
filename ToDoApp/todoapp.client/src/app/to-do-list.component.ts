import { Component, OnInit } from '@angular/core';
import { TodoService } from './services/to-do.service';
import { TodoList } from './models/to-do-list.model';
import { TodoItem } from './models/to-do-list-item.model';

@Component({
  selector: 'app-todo-list',
  templateUrl: './to-do-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
  todoLists: TodoList[] = [];
  newListName: string = '';
  title: string = '';

  constructor(private todoService: TodoService) { }

  ngOnInit(): void {
    this.loadTodoLists();
  }

  loadTodoLists(): void {
    this.todoService.getTodoLists().subscribe(lists => {
      this.todoLists = lists;
    });
  }

  addTodoList(): void {
    if (this.newListName.trim()) {
      const newList: TodoList = { id:"", name: this.newListName };
      this.todoService.createTodoList(newList).subscribe(list => {
        this.todoLists.push(list);
        this.newListName = '';
      });
    }
  }

  deleteTodoList(id: string): void {
    this.todoService.deleteTodoList(id).subscribe(() => {
      this.todoLists = this.todoLists.filter(list => list.id !== id);
    });
  }

  addTodoItem(listId: string, title:string, position: number): void {
    if (this.title.trim()) {
      const newItem: TodoItem = { id:"", listId, title: this.title, isComplete: false, position };
      this.todoService.createTodoItem(newItem).subscribe(item => {
        const list = this.todoLists.find(list => list.id === listId);
        list?.items?.push(item);
        this.title = '';
      });
    }
  }

  deleteTodoItem(listId: string, itemId: string): void {
    this.todoService.deleteTodoItem(itemId).subscribe(() => {
      const list = this.todoLists.find(list => list.id === listId);
      if (list) {
        list.items = list.items?.filter(item => item.id !== itemId);
      }
    });
  }
}
