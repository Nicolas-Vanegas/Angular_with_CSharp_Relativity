import { Component, OnInit, ViewChild } from '@angular/core';
import { DocumentService } from '../services/document.service';
import { CardsComponent } from '../cards/cards.component';

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
  
  selectedDocumentId? :number;

  @ViewChild(CardsComponent, {static: false}) child!: CardsComponent;

  document: string = "";
  filledDocs!: Promise<boolean>;
  documents: Documents[] = [];
  docs: Doc[] = [];
  displayedColumns: string[] = ['demo-position', 'demo-name'];
  workspaceId = 1017767;
  showCards:boolean = false;

  constructor(private documentService: DocumentService){ }

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
    this.selectedDocumentId = artifactId;
    this.showCards = true;
    this.child.printCards(artifactId);
  }
}
