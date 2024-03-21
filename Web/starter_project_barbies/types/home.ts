export interface AcceptanceRate {
    year:number,
    passed:string,
    average:number,
    id:number

}
export interface ServiceDescription {
    title:string,
    link:string,
    description:string,
    id:number,
    is_left:boolean
}
export interface ImpactStory {
    name:string,
    position:string,
    description:string,
    image:string,
    id:number
}