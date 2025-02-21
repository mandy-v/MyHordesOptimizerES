import { ThanksComponent } from './../thanks/thanks.component';
import { Component, Inject, LOCALE_ID, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatToolbar } from '@angular/material/toolbar';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'mho-footer',
    templateUrl: './footer.component.html',
    styleUrls: ['./footer.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class FooterComponent {
    @ViewChild(MatToolbar) mat_toolbar!: MatToolbar;

    public title: string = '';
    /** La liste des langues disponibles */
    public language_list: Language[] = [
        { code: 'en', label: 'English' },
        { code: 'fr', label: 'Français', default: true },
        { code: 'es', label: 'Spanish' },
        { code: 'de', label: 'Deutsch' }
    ];

    /** La langue sélectionnée pour l'affichage de l'application */
    public site_language: Language | undefined;

    public constructor(private title_service: Title, @Inject(LOCALE_ID) private locale_id: string, private dialog: MatDialog) {
        this.title = this.title_service.getTitle();

        /** Si il y a une langue enregistrée, on l'utilise, sinon on utilise le français */
        let used_locale: string = this.locale_id;
        /** Si dans la liste des langues supportées on trouve la langue ci-dessus, on l'utilise, sinon on utilise le français */
        this.site_language = this.language_list.some((language: Language) => used_locale === language.code)
            ? this.language_list.find((language: Language) => used_locale === language.code)
            : this.language_list.find((language: Language) => language.default);
    }

    /**
     * Change la langue sélectionnée
     *
     * @param {Language} new_language
     */
    public changeLanguage(new_language: Language): void {
        console.log('new_language', new_language);
        this.site_language = new_language;
        localStorage.setItem('mho-locale', new_language.code);
        setTimeout(() => {
            location.reload();
        })
    }

    public openThanks(): void {
        this.dialog.open(ThanksComponent, {
            width: '50%',
            minWidth: '250px',
        });
    }
}

interface Language {
    code: string;
    label: string;
    default?: boolean;
}
