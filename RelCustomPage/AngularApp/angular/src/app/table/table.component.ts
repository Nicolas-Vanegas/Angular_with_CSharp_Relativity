import { Component, OnInit, ViewChild } from '@angular/core';
import { DocumentService } from '../services/document.service';
import { CardsComponent } from '../cards/cards.component'
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as action from '../actions/documents.actions'
export interface Doc {
  ArtifactID?: number;
  position: number;
  ControlNumber?: string;
}

export class Documents {
  ArtifactID?: number;
  ControlNumber?: string;
  extractedText?: string;
}

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent implements OnInit{
  
  selectedDocument$?: Observable<any>;

  @ViewChild(CardsComponent, {static: false}) child!: CardsComponent;
  
  filledDocs!: Promise<boolean>;
  documents: Documents[] = [];
  docs: Doc[] = [];
  displayedColumns: string[] = ['demo-position', 'demo-name'];
  workspaceId = 1017767;
  showCards:boolean = false;

  constructor(private documentService: DocumentService, private store: Store<{ selectedDocument: any }>){ }

  ngOnInit() {
    this.documentService.GetDocuments(this.workspaceId).subscribe((x: Documents[]) => {
      x.forEach(s => {
        this.documents.push(s);
      });
      this.fillDocuments(x);
      this.filledDocs = Promise.resolve(true);
    })

  }

  fillDocuments(documents: Documents[])
  {
    var i = 1;
    documents.forEach(doc => {
        this.docs.push({ArtifactID: doc.ArtifactID, position: i, ControlNumber: doc.ControlNumber})
        i++;
      });
  }
  
  GenerateCards(artifactId:number){
    this.selectedDocument$ = this.store.pipe(select('selectedDocument'));
    this.store.dispatch(action.saveSelectedDocumentId({documentId: artifactId}));
    this.showCards = true;
    this.child?.printCards();
  }
}
