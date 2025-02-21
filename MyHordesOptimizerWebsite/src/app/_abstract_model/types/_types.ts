export interface ToolsToUpdate {
    isBigBrothHordes: boolean;
    isFataMorgana: boolean;
    isGestHordes: boolean;
};

export interface SidenavLinks {
    label: string;
    id: string;
    component: any;
    selected: boolean;
}

export type I18nLabels = Dictionary<string>;

export interface Dictionary<T> {
    [key: string | number]: T;
}
