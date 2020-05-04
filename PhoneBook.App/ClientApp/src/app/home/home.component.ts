import { PhoneBookEntry } from './../models/phone-book-entry';
import { Component } from '@angular/core';
import { PhoneBookService } from '../services/phone-book.service';
import { MatDialog } from '@angular/material/dialog';
import { AddEntryDialogComponent } from '../components/add-entry-dialog/add-entry-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {

  constructor(private readonly phoneBookService: PhoneBookService,
    private dialog: MatDialog,
    private _snackBar: MatSnackBar) {
    this.title = 'Phone Book';
  }

  entries: PhoneBookEntry[];
  title: string;

  getEntries(name: string) {
    this.phoneBookService.getEntries(name).subscribe(async response => {
      this.entries = response.data.phoneBookEntries;
    }, async error => {
      console.log(error);
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddEntryDialogComponent, {
      width: '250px'
    });

    dialogRef.afterClosed().subscribe(response => {
      console.log('The dialog was closed');
      if (response as PhoneBookEntry != null) {
        this.saveEntry(response);
      }
    });
  }

  saveEntry(entry: PhoneBookEntry) {
    this.phoneBookService.savEntries(entry).subscribe(async response => {
      this.openSnackBar('saved entry', '');
    }, async error => {
      this.openSnackBar(error.error.message, '');
    });
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }
}
