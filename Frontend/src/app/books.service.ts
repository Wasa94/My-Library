import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Author, Book, Genre } from './types';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  private readonly url = {
    authors: 'https://localhost:44318/api/authors',
    books: 'https://localhost:44318/api/books',
    genres: 'https://localhost:44318/api/books/genres'
  }

  constructor(private http: HttpClient) { }

  getGenres(): Observable<Genre[]> {
    return this.http.get<Genre[]>(this.url.genres);
  }

  getAuthors(): Observable<Author[]> {
    return this.http.get<Author[]>(this.url.authors);
  }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url.books);
  }

  deleteBook(id: number): Observable<Book> {
    const params = new HttpParams().set('id', id);
    return this.http.delete<Book>(this.url.books, { params });
  }

  addBook(book: Book): Observable<Book> {
    return this.http.post<Book>(this.url.books, book);
  }

  editBook(book: Book): Observable<Book> {
    return this.http.put<Book>(this.url.books, book);
  }
}
