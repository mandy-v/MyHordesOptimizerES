import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { ApiServices } from './../_abstract_model/services/api.services';
import { ElementsModule } from './elements/elements.module';
import { MaterialModule } from './material-modules.module';
import { LoadingOverlayService } from './services/loading-overlay.service';
import { SidenavService } from './services/sidenav.service';
import { SnackbarService } from './services/snackbar.service';

let custom_modules: any[] = [MaterialModule, ElementsModule];
let angular_modules: any[] = [BrowserModule, BrowserAnimationsModule, RouterModule, HttpClientModule, FormsModule]

@NgModule({
    imports: [
        ...angular_modules,
        ...custom_modules
    ],
    exports: [
        ...angular_modules,
        ...custom_modules
    ],
    providers: [ApiServices, LoadingOverlayService, SnackbarService, SidenavService]
})

export class SharedModule {
}
