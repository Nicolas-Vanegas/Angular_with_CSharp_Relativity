import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment as env } from '../../environments/environment';
import { Observable  } from 'rxjs';

export class DictionaryAndDocId {
    artifactId?: number;
    dictionaryObjects?: object[];
}

@Injectable()
export class DictionaryService {
  constructor(private http: HttpClient) { }

  GetDictionary(workspaceId: number | string): Observable<DictionaryAndDocId[]> {
    return this.http.get<DictionaryAndDocId[]>(`${env.apiUrl}/${workspaceId}/words`)
  }
}
