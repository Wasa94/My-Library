import { Component, OnInit } from '@angular/core';
import { BookComponent } from './book/book.component';
import { BooksService } from './books.service';
import { Author, Book, BookDialogData, Genre } from './types';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  displayedColumns: string[] = ['id', 'title', 'description', 'genre', 'author', 'modified', 'actions'];

  books: Book[] = [];
  authors: Author[] = [];
  genres: Genre[] = [];
  genresMap: Map<number, string> = new Map();

  constructor(private booksService: BooksService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getGenres();
    this.getAuthors();
    this.getBooks();
  }

  private getBooks(): void {
    this.booksService.getBooks().subscribe(
      (data) => {
        this.books = data;
      },
      (error) => {
        alert(error.message);
      }
    );
  }

  private getAuthors(): void {
    this.booksService.getAuthors().subscribe(
      (data) => {
        this.authors = data;
      },
      (error) => {
        alert(error.message);
      }
    );
  }

  private getGenres(): void {
    this.booksService.getGenres().subscribe(
      (data) => {
        this.genres = data;
        this.genresMap = new Map();
        data.forEach((genre) => {
          this.genresMap.set(genre.key, genre.value);
        });
      },
      (error) => {
        alert(error.message);
      }
    )
  }

  delete(book: Book): void {
    if (confirm(`Are you sure you want to delete "${book.title}"`)) {
      this.booksService.deleteBook(book.id).subscribe(
        (data) => {
          alert('Book successfully deleted!');
          this.books = this.books.filter((book) => book.id != data.id);
        },
        (error) => {
          alert(error.message);
        }
      )
    }
  }

  editBook(book?: Book) {
    const data: BookDialogData = {
      book: book,
      genres: this.genres,
      authors: this.authors
    };

    const dialogRef = this.dialog.open(BookComponent, {
      data: data
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (!result) {
        return;
      }

      if (result.event === 'Add') {
        this.booksService.addBook(result.data).subscribe(
          (data) => {
            alert('Book successfully added!');
            this.getBooks();
          },
          (error) => {
            alert(error.message);
          }
        );
      }
      else if (result.event === 'Edit') {
        this.booksService.editBook(result.data).subscribe(
          (data) => {
            alert('Book successfully edited!');
            this.getBooks();
          },
          (error) => {
            alert(error.message);
          }
        );
      }
    });
  }
}
