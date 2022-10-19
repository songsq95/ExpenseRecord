import { Component, OnInit, OnDestroy, Inject} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RecordItem } from '../models/RecordItem';
import { v4 as uuidv4 } from 'uuid';
import { HttpClient } from '@angular/common/http';
//import { RecordService } from '../services/record.service';

@Component({
  selector: 'app-record-list',
  templateUrl: './record-list.component.html',
  styleUrls: ['./record-list.component.css']
})
export class RecordListComponent implements OnInit, OnDestroy {

  public displayList: RecordItem[] = [];
  private fullList: RecordItem[] = [];
  public item: RecordItem;

  private baseUrl: string;
  private http: HttpClient;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.item = {
      id: 'new',
      description: '',
      type: '',
      amount: null,
      date: new Date().toDateString(),
    };
  }

  ngOnInit(): void {
    this.reload();
  }

  ngOnDestroy(): void {
    //取消订阅（响应式变量）
  }

  reload(): void {
    this.loadData();
  }


  //async navToCreateNew(): Promise<boolean> {
    //return this.router.navigate(['item', 'new'], {
    // relativeTo: this.route.parent
   // });
  //}

  private loadData(): void {
     this.displayList = this.getAll();
     this.fullList = [...this.displayList];
    //this.todoService.getAll().subscribe(res => {
    //  console.log(res);
    //  this.todoService.displayList = res;
    //  this.fullList = [...this.todoService.displayList];
    //})
  }


  getAll(): RecordItem[] {
    return [
      {
        'id': '1',
        'description': 'test1',
        'type': 'meal',
        'amount': 50,
        'date': '2022-01-01',
      },
    ];
  }


  //createOne(body: RecordItem, records: RecordItem[]): RecordItem {
  //  const record: RecordItem = {
  //    ...body,
  //    id: uuidv4(),
  //    date: new Date().toISOString()
  //  };
  //  records.push(record);
  //  return record;
  //}



  //deleteOne(id: string, todos: ToDoItem[]): Observable<string> {
  //  const index: number = todos.findIndex(t => t.id === id);
  ///  todos.splice(index, 1);
  //  this.write(todos);
  //  return of(id);
  //}


  private write(items: RecordItem[]): void {
    localStorage.setItem('records', JSON.stringify(items));
  }


}
