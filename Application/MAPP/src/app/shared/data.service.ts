import { Injectable } from "@angular/core";

export interface DataItem {
    id: number;
    name: string;
    description: string;
}

@Injectable({
    providedIn: "root"
})
export class DataService {

    private items = new Array<DataItem>(
        {
            id: 1,
            name: "Personal Flotation Devices",
            description: "Vessels less than 4.9 meters (16 feet) in length will have aboard a type I, II, III, or V personal flotation device for each person."
             + "Vessels 4.9 meters (16 feet) and over in length shall have aboard a type I, II, III, or V personal flotation device for each person and at least one type IV on board as well as a throwable device."
             + "Each person operating, riding on, or being towed by a personal watercraft must wear a personal flotation device approved by the U.S. Coast Guard." 
             + "All persons under eight (8) years of age, on any vessel, must, at all times, wear a U.S. Coast Guard approved personal flotation device that must be strapped, snapped, or zipped securely in place; except, that no personal flotation device should be required when inside an enclosed cabin or enclosed sleeping space."
            //image path:
        },
        {
            id: 2,
            name: "Flame Arrestors",
            description: "Every motorboat using gasoline as fuel, except outboard motors, shall have the carburetor or carburetors of every engine therein equipped with a U.S."
            + "Coast Guard approved flame arrestor or backfire trap."
        },
        {
            id: 3,
            name: "Emergency Cut-Off Switch",
            description: "No person shall operate or give permission to operate any vessel less than 7.3 meters (24 feet) in length, having an open cockpit and having more than fifty (50) horsepower, unless the said vessel is equipped with an emergency engine or motor shut-off switch."
            + "The shut-off switch shall be a lanyard-type and shall be attached to the person, clothing, or personal flotation device of the operator."
            + "It shall be installed so that when any removal of the operator from the normal operating station will result in the immediate shut-off of the engine."
            + "Any person operating a personal watercraft that does not have self-circling capabilities must have a lanyard-type engine shut-off switch, which must be attached to the person, clothing, or personal flotation device of the operator."
        },
        {
            id: 4,
            name: "Ditch Bags",
            description: "When you prepare for yours, here's what to look for:"
            + "- VHF RADIO should be waterproof like the Lowrance unit at right above."
            + "- PLB such as the Aqualink View activates on command to communicate a position to appropriate rescuers."
            + "- FLARES should be part of your safety kit and are required by law in most federally patrolled water. If you leave the boat, take them with you."
            + "- STROBES like the ACR C-Strobe can save precious time when activated."
            + "- POWERFLARE SAFETY LIGHT and strobes like this (in red case, bottom right) emit SOS or flashing lights to alert rescue personnel."
            + "- SIGNAL MIRRORS can alert rescue personnel in bright daylight, cost practically nothing and are recommended by the USCG."
            + "- WHISTLES are great at attracting rescue personnel when visibility is poor."
        },
        {
            id: 5,
            name: "Item 5",
            description: "Description for Item 5"
        },
        {
            id: 6,
            name: "Item 6",
            description: "Description for Item 6"
        },
        {
            id: 7,
            name: "Item 7",
            description: "Description for Item 7"
        },
        {
            id: 8,
            name: "Item 8",
            description: "Description for Item 8"
        },
        {
            id: 9,
            name: "Item 9",
            description: "Description for Item 9"
        },
        {
            id: 10,
            name: "Item 10",
            description: "Description for Item 10"
        },
        {
            id: 11,
            name: "Item 11",
            description: "Description for Item 11"
        },
        {
            id: 12,
            name: "Item 12",
            description: "Description for Item 12"
        },
        {
            id: 13,
            name: "Item 13",
            description: "Description for Item 13"
        },
        {
            id: 14,
            name: "Item 14",
            description: "Description for Item 14"
        },
        {
            id: 15,
            name: "Item 15",
            description: "Description for Item 15"
        },
        {
            id: 16,
            name: "Item 16",
            description: "Description for Item 16"
        },
        {
            id: 17,
            name: "Item 17",
            description: "Description for Item 17"
        },
        {
            id: 18,
            name: "Item 18",
            description: "Description for Item 18"
        },
        {
            id: 19,
            name: "Item 19",
            description: "Description for Item 19"
        },
        {
            id: 20,
            name: "Item 20",
            description: "Description for Item 20"
        }
    );

    getItems(): Array<DataItem> {
        return this.items;
    }

    getItem(id: number): DataItem {
        return this.items.filter((item) => item.id === id)[0];
    }
}
