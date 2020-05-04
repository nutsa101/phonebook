import { Component, OnInit, Inject } from '@angular/core';
import { PhoneBookEntry } from 'src/app/models/phone-book-entry';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PhoneBookService } from 'src/app/services/phone-book.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-entry-dialog',
  templateUrl: './add-entry-dialog.component.html',
  styleUrls: ['./add-entry-dialog.component.css']
})

export class AddEntryDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<AddEntryDialogComponent>,
    private formBuilder: FormBuilder) {
      this.title = 'New Contact';
  }

  public entryForm: FormGroup;
  title: string;

   ngOnInit() {
    this.entryForm = this.formBuilder.group({
      name: ['', Validators.required],
      phoneNumber: ['', Validators.required]
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
