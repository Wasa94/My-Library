import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Author, Book, BookDialogData, Genre } from '../types';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  form: FormGroup = new FormGroup({
    title: new FormControl(''),
    description: new FormControl(''),
    genre: new FormControl(''),
    author: new FormControl('')
  });

  constructor(public dialogRef: MatDialogRef<BookComponent>,
    @Inject(MAT_DIALOG_DATA) public data: BookDialogData) { }

  ngOnInit(): void {
    this.form.setValue({
      title: this.data.book ? this.data.book.title : '',
      description: this.data.book ? this.data.book.description : '',
      genre: this.data.book ? this.data.book.genre : this.data.genres[0].key,
      author: this.data.book ? this.data.book.authorId : this.data.authors[0].id
    })
  }

  cancel(): void {
    this.dialogRef.close({ event: 'Cancel' });
  }

  save(): void {
    if (!this.form.valid) {
      return;
    }

    const dateNow = new Date();

    const result: Book = {
      id: this.data.book ? this.data.book.id : 0,
      title: this.form.get('title')?.value,
      description: this.form.get('description')?.value,
      genre: this.form.get('genre')?.value,
      authorId: this.form.get('author')?.value,
      createdUtc: dateNow,
      modifiedUtc: dateNow
    };

    const event = this.data.book ? 'Edit' : 'Add';
    this.dialogRef.close({ event: event, data: result });
  }
}
