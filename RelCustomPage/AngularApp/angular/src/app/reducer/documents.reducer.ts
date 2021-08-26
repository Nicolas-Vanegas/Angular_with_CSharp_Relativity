import { state } from "@angular/animations";
import { Action, createFeatureSelector, createReducer, createSelector, on } from "@ngrx/store";
import * as states from '../actions/documents.actions';

export const selectedDocumentIdKey = "selectedDocumentId";

export interface SelectedDocument {
    selectedDocumentId: number
};

export const initialSelectedDocument: SelectedDocument = {
    selectedDocumentId: 0
}

const _documentsReducer = createReducer(
    initialSelectedDocument,
    on(states.saveSelectedDocumentId, (state, {documentId}) => ({ selectedDocumentId: documentId}))
)

export function documentsReducer(state:SelectedDocument | undefined, action: Action) {
    return _documentsReducer(state, action);
}

//selectors
export const getSelectedDocumentIdState = createFeatureSelector<SelectedDocument>('selectedDocument');

export const getSelectedDocumentId = createSelector(
    getSelectedDocumentIdState,
    (state:SelectedDocument) => state.selectedDocumentId
)