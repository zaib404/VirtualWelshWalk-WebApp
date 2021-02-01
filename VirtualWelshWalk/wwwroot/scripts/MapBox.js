import './ExternalScripts.js';

mapboxgl.accessToken = 'pk.eyJ1IjoiemFpYjk3IiwiYSI6ImNrajAzODdncTJuMWIycXNjOG1qZ2lnenkifQ.pyZXLfrmzU-f-FhoHMBd5Q';

var personMarker = new mapboxgl.Marker();
var map;
var draw = false;
var alongLine;
var mapRouteJson;

function readJSON(file) {
    var request = new XMLHttpRequest();
    request.open("GET", file, false);
    request.send(null);
    return JSON.parse(request.responseText);
};

export function initialize() {

    mapRouteJson = readJSON('./scripts/WalkRoute1.json');

    map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v11',
        center: [-2.676758, 51.696951],
        zoom: 7
    });

    var bounds = [
        [-6.731861474246642, 50.900111390703415], // Southwest coordinates
        [-0.41987197913312, 53.574583281115736]]; // Northeast coordinates

    map.setMaxBounds(bounds);

    var WelshWalkMarker = welshMarkers();

    // add markers to map
    WelshWalkMarker.features.forEach(function (marker) {

        var ele = document.createElement('div');
        ele.className = 'marker';
        ele.style.backgroundImage = "url('/Assets/Map-Icon.png')";

        ele.style.width = '62.5px';
        ele.style.height = '81.25px';

        var popup = new mapboxgl.Popup({ offset: [0, -15] })
            .setHTML('<h3>' + marker.properties.title + '</h3><p>' + marker.properties.description + '</p>');

        // add marker to map
        new mapboxgl.Marker(ele)
            .setLngLat(marker.geometry.coordinates)
            .setPopup(popup)
            .addTo(map);
    });

    // add markers to map
    var el = document.createElement('div');
    el.className = 'marker';

    el.style.backgroundImage = "url('/Assets/Walking-Man.png')";
    el.style.width = '63px';
    el.style.height = '99px';

    personMarker = new mapboxgl.Marker(el)
        .setLngLat(mapRouteJson.routes[0].geometry.coordinates[0])
        .setPopup(new mapboxgl.Popup({ offset: [0, -15] })
            .setHTML('<h4>' + "You are here" + '</h4>'))
        .addTo(map);

    map.on('load', function () {
        if (draw)
        {
            addLogo();
            colourPath();
            map.resize();
            map.flyTo({
                center: [personMarker._lngLat.lng, personMarker._lngLat.lat]
            });
        }
    });

    personMarker.getElement().addEventListener('click', () => {
        map.flyTo({
            center: [personMarker._lngLat.lng, personMarker._lngLat.lat],
            zoom: 15.3
        })
    });

    return map;
}

function welshMarkers() {
    var geojson = {
        "features": [
            {
                "type": "Feature",
                "properties": {
                    "title": "Tintern Abbey",
                    "description": "Tintern Abbey - North On The A466, Tintern NP16 6SE"
                },
                "geometry": {
                    "coordinates": [
                        -2.677815,
                        51.697084
                    ],
                    "type": "Point"
                },
                "id": "982b142c055bba0586864a635935db8f"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Transporter Bridge",
                    "description": "Stephenson Street, Newport NP20 2JG"
                },
                "geometry": {
                    "coordinates": [
                        -2.987332,
                        51.571209
                    ],
                    "type": "Point"
                },
                "id": "53c32a4fc578bf46eefee4f16b97773c"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Cardiff Castle",
                    "description": "Castle Street, Cardiff CF10 3RB"
                },
                "geometry": {
                    "coordinates": [
                        -3.181046,
                        51.482255
                    ],
                    "type": "Point"
                },
                "id": "67d840afa4062fbc507b41c2094d7aa0"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Rest Bay Beach",
                    "description": "Rest Bay Beach, Porthcawl CF36 3UW"
                },
                "geometry": {
                    "coordinates": [
                        -3.723539,
                        51.489119
                    ],
                    "type": "Point"
                },
                "id": "10279b7a5a292ebb5cc5116c16182b9e"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Mumbles Pier",
                    "description": "Mumbles Road, Swansea SA3 4EN"
                },
                "geometry": {
                    "coordinates": [
                        -3.977779,
                        51.569108
                    ],
                    "type": "Point"
                },
                "id": "ee1ec07050dd3cd4d88f347c1fc2fba4"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Fall Bay",
                    "description": "Fallbay Cottage Middleton, Rhossili, Swansea SA3 1PL"
                },
                "geometry": {
                    "coordinates": [
                        -4.291874,
                        51.563078
                    ],
                    "type": "Point"
                },
                "id": "abb15fdd2a0fd622c30e76028ab358fc"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Parc y Scarlets",
                    "description": "Maes-Ar-Ddafen Road, Llanelli SA14 9UZ"
                },
                "geometry": {
                    "coordinates": [
                        -4.128446,
                        51.678217
                    ],
                    "type": "Point"
                },
                "id": "b1047062dc5c4e0f0a29e68ad930229d"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Kidwelly Castel",
                    "description": "Castle Road, Kidwelly SA17 5BQ"
                },
                "geometry": {
                    "coordinates": [
                        -4.305838,
                        51.739019
                    ],
                    "type": "Point"
                },
                "id": "c4351f3b33b42f96ef75519938f813a2"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "St Catherine’s Island",
                    "description": "Castle Beach, Tenby SA70 7BL"
                },
                "geometry": {
                    "coordinates": [
                        -4.693686,
                        51.672046
                    ],
                    "type": "Point"
                },
                "id": "87d27027f3bf2c78cdc52017b8c40a40"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Barafundle Bay",
                    "description": "Stackpole Estate, Stackpole SA71 5LS"
                },
                "geometry": {
                    "coordinates": [
                        -4.903263,
                        51.619624
                    ],
                    "type": "Point"
                },
                "id": "5f7e1d4e344b60351a006d75bdd25c88"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Stack Rock Fort",
                    "description": "Pembrokeshire Coast Path, Milford Haven SA73 3RU"
                },
                "geometry": {
                    "coordinates": [
                        -5.093473,
                        51.696745
                    ],
                    "type": "Point"
                },
                "id": "c4183cc4db13c7daf98ec3aa60c7926b"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "St Davids Cathedral",
                    "description": "5A The Pebbles, St Davids SA62 6RD"
                },
                "geometry": {
                    "coordinates": [
                        -5.26807,
                        51.88212
                    ],
                    "type": "Point"
                },
                "id": "eca38fed0eba8bc6b9a0fe5302f12285"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Strumble Head Lighthouse",
                    "description": "Pencaer SA64 0JL"
                },
                "geometry": {
                    "coordinates": [
                        -5.073484,
                        52.029662
                    ],
                    "type": "Point"
                },
                "id": "ae70256aaf880e5542481cba38e73b30"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Cardigan Castle",
                    "description": "Cardigan Castle Green Street, Cardigan SA43 1JA"
                },
                "geometry": {
                    "coordinates": [
                        -4.660502,
                        52.08197
                    ],
                    "type": "Point"
                },
                "id": "9ec4d5b31a2711d39d1028e1f0ec68fc"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "St Padarns Church",
                    "description": "Terrace Road, Aberystwyth SY23 2AG"
                },
                "geometry": {
                    "coordinates": [
                        -4.061308,
                        52.409038
                    ],
                    "type": "Point"
                },
                "id": "1fc57f80d88f70b905c43bc1c507a77d"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Round House",
                    "description": "Barmouth LL42 1HA"
                },
                "geometry": {
                    "coordinates": [
                        -4.052533,
                        52.719312
                    ],
                    "type": "Point"
                },
                "id": "87029f6ced6acae3b6614c38abb65c13"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Harlech Castle",
                    "description": "Ffordd Newydd Road, Harlech LL46 2YH"
                },
                "geometry": {
                    "coordinates": [
                        -4.108895,
                        52.85996
                    ],
                    "type": "Point"
                },
                "id": "5ffa9ef7f5e6197fb9f7f51f5656bb07"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Nant Gwrtheyrnh",
                    "description": "Nant Gwrtheyrn, Llithfaen, Pwllheli, Gwynedd, Wales, Ll53 6Nl, Pwllheli LL53 6NL"
                },
                "geometry": {
                    "coordinates": [
                        -4.458264,
                        52.975332
                    ],
                    "type": "Point"
                },
                "id": "3d4a106e6755dbb19e3b03d9b2f74cdb"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Bedd Gelert",
                    "description": "Dryll Beddgelert, Beddgelert LL55 4NE"
                },
                "geometry": {
                    "coordinates": [
                        -4.10283,
                        53.011971
                    ],
                    "type": "Point"
                },
                "id": "bc3136dbdf29786e63fe07e515827bd7"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Caernarfon Castle",
                    "description": "Castle Ditch, Caernarfon LL55 2AY"
                },
                "geometry": {
                    "coordinates": [
                        -4.276922,
                        53.139061
                    ],
                    "type": "Point"
                },
                "id": "f6030bace85547914f0b8e026f1d7967"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Beaumaris Castle",
                    "description": "Castle Street, Beaumaris LL58 8AP"
                },
                "geometry": {
                    "coordinates": [
                        -4.08984,
                        53.264125
                    ],
                    "type": "Point"
                },
                "id": "9d7a907aa415d2d27aff589b3f117ed2"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "Conwy Castle",
                    "description": "Rose Hill Street, Conwy LL32 8AY"
                },
                "geometry": {
                    "coordinates": [
                        -3.825355,
                        53.280387
                    ],
                    "type": "Point"
                },
                "id": "8bcf34fd15159cf32503b295910ccc19"
            },
            {
                "type": "Feature",
                "properties": {
                    "title": "City Walls",
                    "description": "St Martins Way, Chester CH1 2NR"
                },
                "geometry": {
                    "coordinates": [
                        -2.890356,
                        53.193975
                    ],
                    "type": "Point"
                },
                "id": "9f445beda59430ad2ca78c4669971c64"
            }
        ],
        "type": "FeatureCollection"
    }

    return geojson;
}

function addLogo()
{
    map.loadImage(
        '/Assets/Educ8-Logo.png',
        function (error, image) {
            if (error) throw error;
            map.addImage('logo', image);
            map.addSource('point', {
                'type': 'geojson',
                'data': {
                    'type': 'FeatureCollection',
                    'features': [
                        {
                            'type': 'Feature',
                            'geometry': {
                                'type': 'Point',
                                'coordinates': [-2.7143930352329164, 52.493999147154824]
                            }
                        }
                    ]
                }
            });
            map.addLayer({
                'id': 'points',
                'type': 'symbol',
                'source': 'point',
                'layout': {
                    'icon-image': 'logo',
                    'icon-size': 0.5
                }
            });
        }
    );
}

export function updatePersonIcon(pKM) {
    var json = mapRouteJson;
    var data = json.routes[0];
    var route = data.geometry.coordinates;

    alongLine = {
        type: 'Feature',
        geometry: {
            type: 'LineString',
            coordinates: route
        }
    };

    var options = { units: 'kilometers' };
    var along = turf.along(alongLine, pKM, options);

    // set person icon based on how many steps they have taken
    personMarker.setLngLat(along.geometry.coordinates);

    draw = true;
}

function colourPath() {

    var walkedPathGeoJson = colourWalkedPath();

    var lastElement = walkedPathGeoJson.geometry.coordinates[walkedPathGeoJson.geometry.coordinates.length - 1];

    var index = walkedPathGeoJson.geometry.coordinates.indexOf(lastElement);

    var greyPathGeoJson = GreyPath(index);

    // Green
    map.addLayer({
        id: 'greenRoute',
        type: 'line',
        source: {
            type: 'geojson',
            data: {
                type: 'Feature',
                properties: {},
                geometry: {
                    type: 'LineString',
                    coordinates: walkedPathGeoJson.geometry.coordinates
                }
            }
        },
        layout: {
            'line-join': 'round',
            'line-cap': 'round'
        },
        paint: {
            'line-color': '#008000',
            'line-width': 5,
            'line-opacity': 0.75
        }
    });

    // Grey
    map.addLayer({
        id: 'greyRoute',
        type: 'line',
        source: {
            type: 'geojson',
            data: {
                type: 'Feature',
                properties: {},
                geometry: {
                    type: 'LineString',
                    coordinates: greyPathGeoJson.geometry.coordinates
                }
            }
        },
        layout: {
            'line-join': 'round',
            'line-cap': 'round'
        },
        paint: {
            'line-color': '#888',
            'line-width': 5,
            'line-opacity': 0.75
        }
    });
}

function colourWalkedPath() {
    // grab the nearest point to the marker
    var targetPoint = turf.helpers.point([personMarker._lngLat.lng, personMarker._lngLat.lat]);

    let allGeoPoints = [];

    var i;
    for (i = 0; i < alongLine.geometry.coordinates.length; i++) {
        allGeoPoints.push(turf.helpers.point([alongLine.geometry.coordinates[i][0], alongLine.geometry.coordinates[i][1]]));
    }

    var points = turf.helpers.featureCollection(allGeoPoints);

    var nearest = turf.nearestPoint(targetPoint, points);

    // Grab all coords till it matches the nearest coordinate
    var route = [];

    for (i = 0; i < alongLine.geometry.coordinates.length; i++)
    {
        route.push([alongLine.geometry.coordinates[i][0], alongLine.geometry.coordinates[i][1]]);

        if (alongLine.geometry.coordinates[i][0] == nearest.geometry.coordinates[0] &&
            alongLine.geometry.coordinates[i][1] == nearest.geometry.coordinates[1])
        {
            //route.pop();
            route.push([personMarker._lngLat.lng, personMarker._lngLat.lat]);
            break;
        }
    }

    var geojson = {
        type: 'Feature',
        properties: {},
        geometry: {
            type: 'LineString',
            coordinates: route
        }
    };

    return geojson;

}

function GreyPath(index) {

    // Grab all coords starting from persons locations
    var route = [];

    route.push([personMarker._lngLat.lng, personMarker._lngLat.lat]);

    var i;

    for (i = index; i < alongLine.geometry.coordinates.length; i++) {
        route.push([alongLine.geometry.coordinates[i][0], alongLine.geometry.coordinates[i][1]]);
    }

    var geojson = {
        type: 'Feature',
        properties: {},
        geometry: {
            type: 'LineString',
            coordinates: route
        }
    };

    return geojson;
}

export function LandMarksPassed(pElementId)
{
    // turn person icon to a point
    var targetPoint = turf.helpers.point([personMarker._lngLat.lng, personMarker._lngLat.lat]);

    let allGeoPoints = [];

    // put everything into an array
    for (var i = 0; i < alongLine.geometry.coordinates.length; i++) {
        allGeoPoints.push(turf.helpers.point([alongLine.geometry.coordinates[i][0], alongLine.geometry.coordinates[i][1]]));
    }

    // turn it into a geojson
    var points = turf.helpers.featureCollection(allGeoPoints);

    // grab the nearest point between all the points
    var nearest = turf.nearestPoint(targetPoint, points);

    // Grab all coords of the persons path so far.
    var route = [];

    // loop through inputting each location into route till it matches a coordinate
    for (var i = 0; i < alongLine.geometry.coordinates.length; i++) {
        route.push([alongLine.geometry.coordinates[i][0], alongLine.geometry.coordinates[i][1]]);

        if (alongLine.geometry.coordinates[i][0] == nearest.geometry.coordinates[0] &&
            alongLine.geometry.coordinates[i][1] == nearest.geometry.coordinates[1]) {
            break;
        }
    }

    // grab all marker points
    var welshMarkerPoints = welshMarkers();

    var breakLoop = false;
    var name;

    // loop through every route backwards
    for (var i = route.length - 1; i >= 0; i--)
    {
        for (var ii = welshMarkerPoints.features.length - 1; ii >= 0; ii--)
        {
            // if route matched one of the markers then set name as the latest marker postion and break
            if (route[i][0] == welshMarkerPoints.features[ii].geometry.coordinates[0] &&
                route[i][1] == welshMarkerPoints.features[ii].geometry.coordinates[1])
            {
                breakLoop = true;

                if (ii == 22) {
                    name = welshMarkerPoints.features[ii].properties.title;
                }
                else {
                    name = welshMarkerPoints.features[ii+1].properties.title;
                }

                if (breakLoop)
                {
                    break;
                }
            }
        }

        if (breakLoop) {
            break;
        }
    }

    // Change the dom text
    var header = document.getElementById(pElementId);
    header.innerHTML = name;
}

export function ApproximateStepsToNextMilestone()
{
    // turn person icon to a point
    var targetPoint = turf.helpers.point([personMarker._lngLat.lng, personMarker._lngLat.lat]);

    let allGeoPoints = [];

    // put everything into an array
    for (var i = 0; i < alongLine.geometry.coordinates.length; i++) {
        allGeoPoints.push(turf.helpers.point([alongLine.geometry.coordinates[i][0], alongLine.geometry.coordinates[i][1]]));
    }

    // turn it into a geojson
    var points = turf.helpers.featureCollection(allGeoPoints);

    // grab the nearest point by the person between all the points
    var nearest = turf.nearestPoint(targetPoint, points);

    // Grab all coords of the persons path so far.
    var route = [];

    // loop through inputting each location into route till it matches a coordinate
    for (var i = 0; i < alongLine.geometry.coordinates.length; i++)
    {
        route.push([alongLine.geometry.coordinates[i][0], alongLine.geometry.coordinates[i][1]]);

        if (alongLine.geometry.coordinates[i][0] == nearest.geometry.coordinates[0] &&
            alongLine.geometry.coordinates[i][1] == nearest.geometry.coordinates[1]) {
            break;
        }
    }

    // grab all marker points
    var welshMarkerPoints = welshMarkers();

    var breakLoop = false;
    var markerIndex = 0;

    // loop through all the welsh markers backwards
    for (var i = route.length - 1; i >= 0; i--)
    {
        for (var ii = welshMarkerPoints.features.length - 1; ii >= 0; ii--)
        {
            // if route matched one of the markers then break out
            if (route[i][0] == welshMarkerPoints.features[ii].geometry.coordinates[0] &&
                route[i][1] == welshMarkerPoints.features[ii].geometry.coordinates[1])
            {
                breakLoop = true;

                markerIndex = ii;

                if (ii == welshMarkerPoints.features.length - 1) {
                    markerIndex == ii;
                }
                else {
                    markerIndex == ii + 1;
                }

                if (breakLoop) {
                    break;
                }
            }
        }

        if (breakLoop) {
            break;
        }
    }

    var nextPointMarker = turf.helpers.point([welshMarkerPoints.features[markerIndex].geometry.coordinates[0], welshMarkerPoints.features[markerIndex].geometry.coordinates[1]]);

    var slice = turf.lineSlice([personMarker._lngLat.lng, personMarker._lngLat.lat], nextPointMarker, alongLine.geometry)

    var distance = turf.length(slice, { units: 'miles' })

    return distance;

}

export function UpdateColourPath()
{
    if (map.getLayer('greenRoute'))
    {
        map.removeLayer('greenRoute');
    }

    if (map.getSource('greenRoute')) {
        map.removeSource('greenRoute');
    }


    if (map.getLayer('greyRoute')) {
        map.removeLayer('greyRoute');
    }    
    if (map.getSource('greyRoute')) {
        map.removeSource('greyRoute');
    }

    colourPath();
}