import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment as env } from '../../environments/environment';
import { Observable  } from 'rxjs';

export class Documents {
    ArtifactID?: number;
    ControlNumber?: string;
    extractedText?: string;
}

@Injectable()
export class DocumentService {
  constructor(private http: HttpClient) { }

  GetDocuments(workspaceId: number | string): Observable<Documents[]> {
    return this.http.get<Documents[]>(`${env.apiUrl}/${workspaceId}/documents`)
  }
}
