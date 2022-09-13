import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '../../../helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb:FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  public validation() : void{
    const formOptions : AbstractControlOptions = {
      validators : ValidatorField.mustMatch('senha', 'cSenha')
    };

    this. form = this.fb.group({
      pNome : ["", [Validators.required, Validators.maxLength(50), Validators.minLength(4)]],
      uNome : ["", [Validators.required, Validators.maxLength(50), Validators.minLength(4)]],
      email : ["", [Validators.required, Validators.email]],
      usuario: ["", [Validators.required, Validators.maxLength(15), Validators.minLength(4)]],
      senha : ["", [Validators.required, Validators.minLength(3)]],
      cSenha : ["", Validators.required]
    }, formOptions);
  }
}
