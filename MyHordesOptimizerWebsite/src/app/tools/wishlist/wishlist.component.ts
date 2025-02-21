import { Item } from './../../_abstract_model/types/item.class';
import { Component, ViewChild, ElementRef } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import * as moment from 'moment';
import { HORDES_IMG_REPO } from './../../_abstract_model/const';
import { ApiServices } from './../../_abstract_model/services/api.services';
import { WishlistInfo } from './../../_abstract_model/types/wishlist-info.class';
import { WishlistItem } from './../../_abstract_model/types/wishlist-item.class';
import { MatSelect } from '@angular/material/select';

@Component({
    selector: 'mho-wishlist',
    templateUrl: './wishlist.component.html',
    styleUrls: ['./wishlist.component.scss']
})
export class WishlistComponent {
    @ViewChild(MatSort) sort!: MatSort;
    @ViewChild(MatTable) table!: MatTable<WishlistItem>;
    @ViewChild('addItemFilterInput') add_item_filter_input!: ElementRef;
    @ViewChild('filterInput') filterInput!: ElementRef;
    @ViewChild('addItemSelect') add_item_select!: MatSelect;

    /** La wishlist */
    public wishlist_info!: WishlistInfo;
    /** La datasource pour le tableau */
    public datasource: MatTableDataSource<WishlistItem> = new MatTableDataSource();
    /** Le dossier dans lequel sont stockées les images */
    public HORDES_IMG_REPO: string = HORDES_IMG_REPO;
    /** La locale */
    public locale: string = moment.locale();
    /** La liste des colonnes */
    public readonly columns: WishlistColumns[] = [
        { id: 'name', header: $localize`Nom de l'objet` },
        { id: 'priority', header: $localize`Priorité` },
        { id: 'bank_count', header: $localize`Stock en banque` },
        { id: 'count', header: $localize`Stock souhaité` },
        { id: 'needed', header: $localize`Quantité manquante` },
        { id: 'delete', header: `` },
    ];
    /** La liste des colonnes */
    public readonly columns_ids: string[] = this.columns.map((column: WishlistColumns) => column.id);

    public items: Item[] = [];

    /** La liste des priorités */
    public readonly priorities: Priorities[] = [
        { count: -1000, label: $localize`Ne pas ramener` },
        { count: 0, label: $localize`Non définie` },
        { count: 1000, label: $localize`Basse` },
        { count: 2000, label: $localize`Moyenne` },
        { count: 3000, label: $localize`Haute` }
    ]

    constructor(private api: ApiServices) {

    }
    
    ngOnInit(): void {
        this.datasource = new MatTableDataSource();
        this.datasource.sort = this.sort;
        this.datasource.filterPredicate = (data: WishlistItem, filter: string) => this.customFilter(data, filter);
        this.getWishlist();
        this.api.getItems().subscribe((items: Item[]) => {
            this.items = items;
        });
    }

    /** Met à jour la liste de courses */
    public updateWishlist(): void {
        this.api.updateWishlist(this.wishlist_info).subscribe((wishlist_info: WishlistInfo) => {
            this.wishlist_info = wishlist_info;
            this.datasource.data = wishlist_info.wishlist_items;
        })
    }

    /** Filtre la liste à afficher */
    public applyFilter(event: Event): void {
        const value: string = (event.target as HTMLInputElement).value;
        this.datasource.filter = value.trim().toLowerCase();

    }

    /** Retire une ligne de la liste */
    public remove(row: WishlistItem) {
        let index = this.wishlist_info.wishlist_items.findIndex((wishlist_item: WishlistItem) => wishlist_item.item.xml_id === row.item.xml_id);
        this.wishlist_info.wishlist_items.splice(index, 1);
        this.datasource.data = [...this.wishlist_info.wishlist_items];
    }

    public isObjectDisplayed(item: Item): boolean {
        let display_by_filter: boolean = item.label[this.locale].toLowerCase()
        .indexOf(this.add_item_filter_input ? this.add_item_filter_input.nativeElement.value.toLowerCase() : '') > -1;
        let not_in_wishlist: boolean = item.wishlist_count === 0;
        return display_by_filter && not_in_wishlist;
    }

    public addItemToWishlist(item: Item) {
        this.api.addItemToWishlist(item).subscribe(() => {
            item.wishlist_count = 1;
            this.add_item_select.value = undefined;
            this.add_item_filter_input.nativeElement.value = '';
            this.getWishlist();
        })
    }

    /** Remplace la fonction qui vérifie si un élément doit être remonté par le filtre */
    private customFilter(data: WishlistItem, filter: string): boolean {
        if (data.item.label[this.locale].toLowerCase().indexOf(filter.toLowerCase()) > -1) return true;
        return false;
    }

    private getWishlist(): void {
        this.api.getWishlist().subscribe((wishlist_info: WishlistInfo) => {
            this.wishlist_info = wishlist_info;
            this.datasource.data = [...wishlist_info.wishlist_items];
        });
    }
}

interface Priorities {
    count: number;
    label: string;
}

interface WishlistColumns {
    header: string;
    id: string;
}
