import { Component, OnInit, OnDestroy, Inject} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RecordItem } from '../models/RecordItem';
import { v4 as uuidv4 } from 'uuid';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
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
  private httpUrl = " https://localhost:7081/api";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.item = {
      id: 'new',
      description: '',
      type: '',
      amount: null,
      date: '',
    };
  }

  ngOnInit(): void {
    this.loadData();
  }

  ngOnDestroy(): void {
    //取消订阅（响应式变量）
  }

  //reload(): void {
  //  this.loadData();
  //}


  //async navToCreateNew(): Promise<boolean> {
    //return this.router.navigate(['item', 'new'], {
    // relativeTo: this.route.parent
   // });
  //}

  private loadData(): void {
    this.getAll().subscribe(res => {
      console.log(res);
      this.displayList = res;
      //this.fullList = [...this.displayList];
    })
  }

  getAll(): Observable<RecordItem[]> {
    return this.http.get<RecordItem[]>(this.httpUrl);
  }

  private loadDataInit(): void {
    this.displayList = this.getAllInit();
    //this.fullList = [...this.displayList];
  }

  getAllInit(): RecordItem[] {
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

  save(): void {
    this.createOne(this.item).subscribe({
    });
    this.loadData();
    
  }

  private createOne(body: RecordItem): Observable<RecordItem> {
    const record: RecordItem = {
      ...body,
      id: uuidv4(),
    };
    return this.http.post<RecordItem>(this.httpUrl, record);
  }
  
  


  delete(body: RecordItem): void {
    const ok = confirm(`Delete this item?`);
    if (ok) {
        this.deleteOne(body.id).subscribe(() => {
        });
      
    }
    this.loadData();

  }

  private deleteOne(id: string): Observable<string> {
    const httpUrlId = this.httpUrl + "/" + id;
    return this.http.delete<string>(httpUrlId);
  }

}
