import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './contact.html',
  styleUrls: ['./contact.css']
})
export class ContactComponent {

  // Contact list
  contacts = [
    { contactId: 1, name: 'Aishwarya', email: 'aish@gmail.com', phone: '9876543210', isActive: true },
    { contactId: 2, name: 'Rahul', email: 'rahul@gmail.com', phone: '9876543211', isActive: false }
  ];

  // Template form model
  newContact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    isActive: false
  };

  // Reactive form
  reactiveForm!: FormGroup;

  constructor(private fb: FormBuilder) {
    this.reactiveForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.minLength(10)]],
      isActive: [false]
    });
  }

  // Template form submit
  addContact(form: any) {
    if (form.valid) {
      this.newContact.contactId = this.contacts.length + 1;
      this.contacts.push({ ...this.newContact });
      form.reset();
    }
  }

  // Reactive form submit
  submitReactiveForm() {
    if (this.reactiveForm.valid) {
      const newContact = {
        contactId: this.contacts.length + 1,
        ...this.reactiveForm.value
      };
      this.contacts.push(newContact);
      this.reactiveForm.reset();
    }
  }
}