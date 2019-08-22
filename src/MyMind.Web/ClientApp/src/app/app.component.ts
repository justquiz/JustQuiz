import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IEmotion } from '../models/iEmotion';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private _httpService: HttpClient) { }

  emotions: IEmotion[] = [];
  error: any;

  ngOnInit(): void {
      this._httpService.get<IEmotion[]>('api/Emotions/GetEmotions')
      .subscribe(values => this.emotions = values,
                  error => this.error = error);
  }

  title = 'MyMind';
}
