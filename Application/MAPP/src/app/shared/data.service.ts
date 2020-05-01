import { Injectable } from "@angular/core";

export interface DataItem {
    id: number;
    name: string;
    image: string;
    description: string;
    link: string;
}

@Injectable({
    providedIn: "root"
})
export class DataService {

    private items = new Array<DataItem>(
        {
            id: 1,
            name: "Personal Flotation Devices",
            image: "~/app/shared/Assets/Images/PFDTypes.jpg",
            description: "Vessels less than 4.9 meters (16 feet) in length will have aboard a type I, II, III, or V personal flotation device for each person."
             + "Vessels 4.9 meters (16 feet) and over in length shall have aboard a type I, II, III, or V personal flotation device for each person and at least one type IV on board as well as a throwable device."
             + "Each person operating, riding on, or being towed by a personal watercraft must wear a personal flotation device approved by the U.S. Coast Guard. \n \n" 
             + "All persons under eight (8) years of age, on any vessel, must, at all times, wear a U.S. Coast Guard approved personal flotation device that must be strapped, snapped, or zipped securely in place; except, that no personal flotation device should be required when inside an enclosed cabin or enclosed sleeping space. \n \n \n \n"
             + "CAUTION: \n \n" + "Personal flotation devices must be accessible and of the proper size. Those that are torn, rotted, and damaged, lose their approval. \n \n"
             + "CAUTION: \n \n" + "A type V personal flotation device is a PFD approved for restricted uses. Type V PFD's must be worn in open boats and when on the deck of larger boats in order to be classified as U.S. Coast Guard approved. \n \n"
             + "For more information, visit www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
            
        },
        {
            id: 2,
            name: "Flame Arrestors",
            image: "~/app/shared/Assets/Images/FlameArrestor.jpg",
            description: "Every motorboat using gasoline as fuel, except outboard motors, shall have the carburetor or carburetors of every engine therein equipped with a U.S."
            + "Coast Guard approved flame arrestor or backfire trap.",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
        },
        {
            id: 3,
            name: "Emergency Cut-Off Switch",
            image: "~/app/shared/Assets/Images/EmergencyCutOffSwitch.jpg",
            description: "No person shall operate or give permission to operate any vessel less than 7.3 meters (24 feet) in length, having an open cockpit and having more than fifty (50) horsepower, unless the said vessel is equipped with an emergency engine or motor shut-off switch. \n \n"
            + "The shut-off switch shall be a lanyard-type and shall be attached to the person, clothing, or personal flotation device of the operator."
            + "It shall be installed so that when any removal of the operator from the normal operating station will result in the immediate shut-off of the engine. \n \n"
            + "Any person operating a personal watercraft that does not have self-circling capabilities must have a lanyard-type engine shut-off switch, which must be attached to the person, clothing, or personal flotation device of the operator.",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
        },
        {
            id: 4,
            name: "Ditch Bags",
            image: "~/app/shared/Assets/Images/ditchbag.jpg",
            description: "When you prepare for yours, here's what to look for: \n \n"
            + "- VHF RADIO should be waterproof like the Lowrance unit at right above. \n \n"
            + "- PLB such as the Aqualink View activates on command to communicate a position to appropriate rescuers. \n \n"
            + "- FLARES should be part of your safety kit and are required by law in most federally patrolled water. If you leave the boat, take them with you. \n \n"
            + "- STROBES like the ACR C-Strobe can save precious time when activated. \n \n"
            + "- POWERFLARE SAFETY LIGHT and strobes like this (in red case, bottom right) emit SOS or flashing lights to alert rescue personnel. \n \n"
            + "- SIGNAL MIRRORS can alert rescue personnel in bright daylight, cost practically nothing and are recommended by the USCG. \n \n"
            + "- WHISTLES are great at attracting rescue personnel when visibility is poor. \n \n"
            + "- ROPE can keep the crew together should a lifeboat not be available. \n \n"
            + "- A GERBER HINDERER serrated blunt-point knife is less likely to puncture a life raft and will make quick work of slicing ropes or bandages. \n \n"
            + "- FIRST AID KITS should include a ready supply of essential medications you may need on a frequent basis. \n \n"
            + "- DRINKING WATER should be accompanied by a measuring device to carefully apportion it to maintain lifea nd morale. \n \n"
            + "- SUNSCREEN and DRAMAMINE can ease discomfort adrift. \n \n",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
        },
        {
            id: 5,
            name: "Federally Controlled Waters",
            image: "",
            description: "Boat and PWC operators must observe federal regulations when boating on: \n"
            + "- Coastal Waters \n"
            + "- The Great Lakes \n"
            + "- Territorial Seas \n"
            + "- Waters which are two miles wide or wider and are connected to one of the above.",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
        },
        {
            id: 6,
            name: "Fire Extinguishers",
            image: "~/app/shared/Assets/Images/FireExtinguisher1.jpg",
            description: "All vessels, as herein designated, must be equipped with a serviceable U.S. Coast Guard approved fire extinguisher of the type and capacity indicated. \n \n"
            + "1. All inboard and inboard/outboard vessels, regardless of size, and all motor vessels having closed compartments wherein portable fuel tanks are stored or having permanentely"
            + "installed fuel tanks shall have a hand portable or semi-portable fire extinguisher using carbon dioxide (CO2), foam, or other chemical ingredients such as is commonly used for"
            + "extinguishing gasoline fires or petroleum product fires. Such fire extinguisher shall be approved by the U.S. Coast Guard. \n \n"
            + "2. All vessels equipped with any butane gas, propane gas, kerosene, gasoline or petroleum product consuming device except outboard motors, such as a stove or lantern shall have a hand"
            + "portable or semi-portable fire extinguisher using carbon dioxide (CO2), foam, or other chemical ingredient such as is commonly used for extinguishing a fire produced by the use"
            + "of such device. Such fire extinguisher shall be approved by the U.S. Coast Guard. \n \n"
            + "3. All motor vessels having closed or semi-closed cabins and any vessel with sleeping accommodations shall have a hand portable fire extinguisher or semi-portable fire extinguisher"
            + "using carbon dioxide (CO2), foam, or other chemical ingredients such as is commonly used for extinguishing fires. Such fire extinguisher shall be approved by the U.S. Coast Guard. \n \n \n"
            + "*Flammable liquids include gasoline, kersosene, oil and stove alcohol.",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
        },
        {
            id: 7,
            name: "Diver's Flag",
            image: "~/app/shared/Assets/Images/DiversFlags.jpg",
            description: "The diver's flag will be at least 300 mm (12 inches) square, colored red with a white 500 mm (2 inches) stripe running diagonally from the top staff cornor to the bottom"
            + "fly corner. Boat owners will stay at least 30.5 meters (100 feet) away from the displayed flag.",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
        },
        {
            id: 8,
            name: "Lights and Sound Devices",
            image: "~/app/shared/Assets/Images/NavigationLights.jpg",
            description: "Lights \n \n \n" + "All vessels must be equipped with prescribed navigation lights when operated at night in accordance with the Boating Safety Laws. Operators of all vessels"
            + "must comply with the requirements for the type and use of lights when anchored or underway from sunset to sunrise. \n \n \n \n" + "Sound Devices \n \n \n" + "All vessels 4.9 meters (16 feet) or more"
            + "in length must have on board the proper signal device for use during nighttime operation or inclement weather where visibility is greatly reduced.",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
        },
        {
            id: 9,
            name: "Visual Distress Signals",
            image: "~/app/shared/Assets/Images/USCoastGuardApprovedVisualDistressSignals.jpg",
            description: "Visual Distress Signals (VDSs) allow boat operators to signal for help in the event of an emergency. \n \n" + "VDSs are classified as day signals (visible in bright sunlight), night signals (visible at night)"
            + "or both day and night signals. \n \n" + "VDSs are either pyrotechnic (smoke and flames) or non-pyrotechnic (non-combustible).",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
        },
        {
            id: 10,
            name: "Coast Guard Emergency Contact",
            image: "",
            description: "Seventh District Command Center Number: \n \n" + "(305)-415-6800",
            link: "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama"
        }
    );

    private regulations = new Array<DataItem>(
        {
            id: 1,
            name: "Species Reporting",
            image: "~/app/shared/Assets/Images/redSnapper.jpg",
            description: "Species with mandatory reporting: \n1. Red Snapper\n\nNote: Only one report per vessel trip\n\n\n"+
            "Species with voluntary reporting: \n1. Gray Triggerfish \n2. Greater Amberjack \n\nNote: Only one report per vessel trip\n\n\n"+
            "Download the Outdoor AL App for Game Check and Snapper Check \nhttps://apps.apple.com/us/app/outdoor-al/id1381147009",
            link:"https://apps.apple.com/us/app/outdoor-al/id1381147009"
        },
        {
            id: 2,
            name: "Saltwater Fishing Licenses",
            image: "~/app/shared/Assets/Images/SaltwaterFishingLicenseMap.jpg",
            description: "A Saltwater Fishing License is required for all persons fishing or possessing in fish in saltwater areas of Alabama.\n\n\nClick here to purchase a Saltwater Fishing License",
            link: "https://www.outdooralabama.com/licenses/saltwater-recreational-licenses"
        },
        {
            id: 3,
            name: "Freshwater Fishing Licenses",
            image: "~/app/shared/Assets/Images/freshwaterLicensePlate.jpg",
            description: "To support fish management and aquatic resources, purchase a fishing license. \n\n\nClick here to purchase a Freshwater Fishing License \n",
            link: "https://www.outdooralabama.com/licenses/freshwater-fishing-licenses"
        },
        {
            id: 4,
            name: "Saltwater Recreational Size & Creel Limits",
            image: "~/app/shared/Assets/Images/SizeAndCreelLimit.jpg",
            description: "Click Below to go to Alabama recreational fishing document.\n\n",
            link: "https://www.outdooralabama.com/sites/default/files/PDF%20documents/Creel%20Limits%20B&W%20for%20printing.pdf"
        },
        {
            id: 5,
            name: "2020 Alabama Marine Information Calendar",
            image: "",
            description: "Click Below to go to 2020 Alabama Marine Information Calendar",
            link: "https://www.outdooralabama.com/sites/default/files/fishing/Saltwater/2020%20MRD%20Calendar.pdf"
        },
        {
            id: 6,
            name: "Hook Requirements",
            image: "",
            description: "Anglers fishing for retaining, possessing, or landing gulf reef species (as defined in Rule 220-3-46) must use non-stainless steel circle hooks when using natural bait."
            + "\n\nAnglers fishing for retaining, possessing, or landing sharks must use non-offset, non-stainless steel circle hooks when using natural bait.",
            link: "https://www.outdooralabama.com/fishing/saltwater-fishing"
        },
        {
            id: 7,
            name: "Saltwater Registry",
            image: "",
            description: "FREE Saltwater Angler Registration is required for all residents 16 and over who take, catch, kill, or possess fish or attempt to catch, kill or possess fish in the saltwater jurisdiction of Alabama.  This includes residents who are not required to purchase an annual saltwater license such as those over the age of 64, have a lifetime saltwater license or fish exclusively on a pier that has purchased a pier fishing license."
            + "\n\nStart by clicking on the link below:",
            link: "https://www.alabamainteractive.org/dcnr_hf_license/welcome.action?sp=OA2AI"
        },
        {
            id: 8,
            name: "Saltwater Reminders & Regulation Changes",
            image: "~/app/shared/Assets/Images/saltwaterSpottedSeaTrout.jpg",
            description: "****REMINDER****"
            + "\n\nAlabama's 2020 private angler red snapper season opens Friday, May 22, 2020. The season is anticipated to last for 35 days and is scheduled to close on Sunday, July 19, 2020. Weekends only (Friday-Monday)."
            + "\n\nYellowfin Tuna now has a creel limit of 3 per person."
            + "\n\nRecreational harvest of gray triggerfish will open at 12:01 a.m. on March 1, 2020, and close at 12:01 a.m., local time, on May 2, 2020."
            + "\n\nFlounder - possessing, taking, or attempting to take flounder harvested in the waters of Alabama for commercial or recreational purposes from November 1 through November 30 is prohibited."
            + "\n\n\nRegulation Changes Beginning August 1, 2019"
            + "\n\nCobia \n-36 inches fork length"
            + "\n\nSpotted Sea Trout \n-Slot Length is 15 inches total length to 22 inches total length \n6 per person, per day with one over 22 inches total length allowed"
            + "\n\nFlounder \n-14 inches total length (recreational and commercial) \nRecreational creel limit is 5 per person \nCommercial creel limit is 40 per person or 40 per vessel \nClosed season for flounder is November 1 through November 30 for both recreational and commercial anglers",
            link: "https://www.outdooralabama.com/fishing/saltwater-fishing"
        },
        {
            id: 9,
            name: "Silver/Jumping Carp Urgency",
            image: "~/app/shared/Assets/Images/SilverCarp.jpg",
            description: "Invasive Asian Carp: the Feral Hog of Alabama's Waterways\n\n"
            + "Asian carp have long been a problem in other parts of the country, but these fish are now working their way into Alabama. Because of the threat posed by Asian carp, the Fisheries Section of the Alabama Division of Wildlife and Freshwater Fisheries is working to protect the state’s aquatic resources from this invasive species."
            + "\n\nFour species of Asian carp have been introduced in the U.S. Those species include silver carp, bighead carp, grass carp, and black carp. Of these species, silver and black carp are the greatest immediate threat to Alabama’s aquatic resources."
            + "\n\nIn the same way feral hogs devastate habitat resources for native wildlife, silver carp have the potential to outcompete with other native species for food, including important game fish. Currently, the area of concern for silver carp in Alabama is the Tennessee and Tombigbee Rivers."
            + "\n\nThese invasive fish can also harm boaters. Silver carp tend to jump out of the water when startled. A jumping carp strike can cause serious injury to anyone on board a vessel. This occurs most commonly in shallow water. If boaters experience jumping carp, they should slowly retreat from the area to avoid impact."
            + "\n\nAlabama has joined forces with the Tennessee Wildlife Resources Agency and the Mississippi Department of Wildlife, Fisheries and Parks to work on silver and other Asian carp species management and control. A multiple-state group called the Mississippi Interstate Cooperative Resources Association has also been formed by the 28 states in the Mississippi River basin to collectively address this issue.",
            link: "https://www.outdooralabama.com/silverjumping-carp-urgency"
        },
        {
            id: 10,
            name: "Freshwater Game Fish",
            image: "",
            description: "Black Bass - largemouth, smallmouth, spotted, Alabama, shoal, and those species formerly known as 'redeye' bass, which are now known separately as Coosa, Warrior, Cahaba, Tallapoosa, and Chattahoochee bass, based on their respective drainages. The Alabama bass was formerly known as spotted bass in the Mobile drainage."
            + "\n\nBream (Sunfish) - rock bass, flier, shadow bass, warmouth, redbreast, bluegill, longear, and redear (shellcracker)."
            + "\n\nCrappie - black and white crappie."
            + "\n\nTemperate Bass - saltwater striped, white, and yellow bass and any hybrids thereof."
            + "\n\nPickerel - chain, redfin, and grass pickerel."
            + "\n\nPerch - sauger(jack), walleye, and yellow perch."
            + "\n\nTrout - rainbow trout.",
            link: "https://www.outdooralabama.com/freshwater-fishing/game-fish"
        },
        {
            id: 11,
            name: "Freshwater Non-Game Fish",
            image: "",
            description: "Drum \nCarp \nCatfish \nPaddlefish \nSucker \nBowfin \nGar \nMullet",
            link: "https://www.outdooralabama.com/freshwater-fishing/commercial-or-non-game-fish"
        },
        {
            id: 12,
            name: "Aquatic Nuisance Species",
            image: "",
            description: "Only you can help prevent the spread of aquatic nuisance species."
            + "\n-Remove any visible mud, plants, fish or animals before transporting equipment."
            + "\n-Eliminate water from equipment before transporting."
            + "\n-Clean and dry anything that came in contact with water (boats, trailers, equipment, clothing, dogs, etc.)."
            + "\n-It is illegal to release bait or stock fish or other aquatic organisms in Alabama without a specific permit. Never release plants, fish or animals into a body of water unless they came out of that body of water.  Use aquatic baits already present in the waters.  Possession or distribution of some plants is illegal."
            + "\n-Anglers and boaters need to do what they can to prevent the spread of nuisance aquatic species."
            + "\n\nAsian Carp \nLearn more about the Asian Carp and why it is a nuisance species at the link below:",
            link: "https://www.outdooralabama.com/freshwater-fishing/aquatic-nuisance-species"
        },
        {
            id: 13,
            name: "Aquatic Plants of Alabama",
            image: "~/app/shared/Assets/Images/freshwaterAquaticPlants.jpg",
            description: "Alabama Regulation 220-2-124: Alabama Nonindigenous Aquatic Plant Control Act"
            + "\n\nFor  the purposes of enforcement of Sections 9-20-1 through 9-20-7, Code of Alabama 1975, enacted by Act No. 95-767, as the 'Alabama Nonindigenous Aquatic Plant Control Act,' the following list of all nonindigenous aquatic plants which are prohibited by Section 9-20-3 from being introduced or placed or caused to be introduced or placed into public waters of the state is established:"
            + "\n\nAfrican elodea, alligatorweed, Brazilian elodea, curlyleaf pondweed, Eurasian watermilfoil, floating waterhyacinth, giant salvinia, hydrilla, hygrophila, limnophila, parrot-feather, purple loosestrife, rooted waterhyacinth, spinyleaf naiad, water-aloe, water lettuce, water chestnut, and water spinach"
            + "\n\nAquatic plants that are illegal under federal law as of June 30, 2006, include: mosquito fern or water velvet (Azolla pinnata), Mediterranean clone of caulerpa (Caulerpa taxifolia), anchored waterhyacinth (Eichornia azurea), hydrilla (Hydrilla verticillato), Miramar weed (Hygrophila polysperma), water-spinach (Ipomoea aquatica), Lagarosiphon major, ambulia (Limnophila sessiliflora), Melaleuca quinquenervia, Monochoria hastata, Ottelia alismoides, arrowhead (Sagittaria sagittifola), giant Salvina (Salvinia auriculata, S. biloba, S. herzogii, and S. molesta), wetland nightshade (Solanum tampicense), exotic bur-reed (Sparganium erectum).",
            link: "https://www.outdooralabama.com/freshwater-fishing/aquatic-plants-alabama"
        },
        {
            id: 14,
            name: "Contacts",
            image: "",
            description: "24-Hour Contact Number: (251) 476-1256"
            + "\n\nIf you need to reach someone in the Administrative, Fisheries, or Enforcement section, please click the link below.",
            link: "https://www.outdooralabama.com/saltwater-fishing/saltwater-contacts"
        },
    );

    getItems(): Array<DataItem> {
        return this.items;
    }

    getItem(id: number): DataItem {
        return this.items.filter((item) => item.id === id)[0];
    }

    getRegulations(): Array<DataItem> {
        return this.regulations;
    }

    getRegulation(id: number): DataItem {
        return this.regulations.filter((regulation) => regulation.id === id)[0];
    }
}
