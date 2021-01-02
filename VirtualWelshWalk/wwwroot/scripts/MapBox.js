﻿import 'https://api.mapbox.com/mapbox-gl-js/v2.0.0/mapbox-gl.js';

mapboxgl.accessToken = 'pk.eyJ1IjoiemFpYjk3IiwiYSI6ImNrajAzODdncTJuMWIycXNjOG1qZ2lnenkifQ.pyZXLfrmzU-f-FhoHMBd5Q';

var personMarker = new mapboxgl.Marker();
var map;

export function initialize() {
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
        var popup = new mapboxgl.Popup({ offset: [0, -15] })
            .setHTML('<h3>' + marker.properties.title + '</h3><p>' + marker.properties.description + '</p>');

        // add marker to map
        new mapboxgl.Marker()
            .setLngLat(marker.geometry.coordinates)
            .setPopup(popup)
            .addTo(map);
    });

    // add markers to map
    var el = document.createElement('div');
    el.className = 'marker';

    personMarker = new mapboxgl.Marker(el)
        .setLngLat(directionAPI().routes[0].geometry.coordinates[0])
        .setPopup(new mapboxgl.Popup({ offset: [0, -15] })
            .setHTML('<h4>' + "You are here" + '</h4>'))
        .addTo(map);

    map.on('load', function ()
    {
        drawPath(map);
    });

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
                        -2.676758,
                        51.696951
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
                        -2.987047,
                        51.571205
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
                        -3.181199,
                        51.4824
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
                        -3.72351,
                        51.489127
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
                        -3.97508,
                        51.569502
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
                        -4.291686,
                        51.56257
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
                        -4.128228,
                        51.678375
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
                        -4.306339,
                        51.739136
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
                        -4.691669,
                        51.670491
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
                        -4.904206,
                        51.618515
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
                        -5.092088,
                        51.702564
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
                        -5.268446,
                        51.882029
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
                        -5.073719,
                        52.029812
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
                        -4.660491,
                        52.081882
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
                        -4.060874,
                        52.409171
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
                        -4.052523,
                        52.719298
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
                        -4.108899,
                        52.860019
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
                        -4.458386,
                        52.975466
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
                        -4.102831,
                        53.011968
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
                        -4.276934,
                        53.139147
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
                        -4.089712,
                        53.264872
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
                        -3.825617,
                        53.280071
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
                        -2.890298,
                        53.193988
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

function drawPath(map) {
    var json = directionAPI();
    var data = json.routes[0];
    var route = data.geometry.coordinates;

    var geojson = {
        type: 'Feature',
        properties: {},
        geometry: {
            type: 'LineString',
            coordinates: route
        }
    };

    map.addLayer({
        id: 'route',
        type: 'line',
        source: {
            type: 'geojson',
            data: {
                type: 'Feature',
                properties: {},
                geometry: {
                    type: 'LineString',
                    coordinates: geojson.geometry.coordinates
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

function directionAPI() {
    var directions =
    {
        "routes": [
            {
                "weight_name": "pedestrian",
                "weight": 577660.671,
                "duration": 529399.083,
                "distance": 767844.125,
                "legs": [
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 21451.346,
                        "distance": 30382.779,
                        "weight": 21635.854,
                        "summary": "A48, B4237"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 13039.854,
                        "distance": 18493.852,
                        "weight": 13358.445,
                        "summary": "Cardiff Road, Newport Road"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 29295.109,
                        "distance": 41574.91,
                        "weight": 29641.164,
                        "summary": "A48, B4524"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 27116.807,
                        "distance": 38491.645,
                        "weight": 27478.354,
                        "summary": "A48, Fabian Way"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 17611.455,
                        "distance": 25001.168,
                        "weight": 17771.455,
                        "summary": "A4118, B4247"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 21452.801,
                        "distance": 30457.285,
                        "weight": 22307.094,
                        "summary": "B4295, A484"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 11233.692,
                        "distance": 15937.64,
                        "weight": 11379.185,
                        "summary": "Old Road, B4308"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 32982.68,
                        "distance": 46054.586,
                        "weight": 39870.918,
                        "summary": "Port Way, B4316"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 13737.784,
                        "distance": 19501.963,
                        "weight": 21602.795,
                        "summary": "A4139, Jason Road"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            },
                            {
                                "iso_3166_1_alpha3": "IRL",
                                "iso_3166_1": "IE"
                            }
                        ],
                        "duration": 10899.878,
                        "distance": 23867.424,
                        "weight": 10341.13,
                        "summary": "A4139, Pembroke Dock to Rosslare"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "IRL",
                                "iso_3166_1": "IE"
                            },
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 29443.607,
                        "distance": 50587.137,
                        "weight": 29018.863,
                        "summary": "Pembroke Dock to Rosslare, A487"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 18441.803,
                        "distance": 26180.248,
                        "weight": 18566.805,
                        "summary": "A487, Trefasser Cross"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 25446.051,
                        "distance": 36130.531,
                        "weight": 26335.34,
                        "summary": "A487, B4582"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 42955.793,
                        "distance": 60991.543,
                        "weight": 43801.152,
                        "summary": "A487, Rhiw Goch"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 44612.84,
                        "distance": 63348.766,
                        "weight": 44810.371,
                        "summary": "A487, A493"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 12391.858,
                        "distance": 17589.34,
                        "weight": 12426.858,
                        "summary": "A496, Ffordd Uchaf"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 31246.531,
                        "distance": 44365.789,
                        "weight": 31394.203,
                        "summary": "B4573, A487"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 24432.859,
                        "distance": 34686.129,
                        "weight": 24562.859,
                        "summary": "Llys Eben, A4085"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 14519.35,
                        "distance": 20617.475,
                        "weight": 14584.49,
                        "summary": "A4085, B4419"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 14084.192,
                        "distance": 19979.658,
                        "weight": 21539.266,
                        "summary": "A487, A545"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 23887.238,
                        "distance": 33895.746,
                        "weight": 38502.664,
                        "summary": "A545, A55"
                    },
                    {
                        "steps": [],
                        "admins": [
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            },
                            {
                                "iso_3166_1_alpha3": "GBR",
                                "iso_3166_1": "GB"
                            }
                        ],
                        "duration": 49115.555,
                        "distance": 69708.508,
                        "weight": 56731.406,
                        "summary": "A547, A55"
                    }
                ],
                "geometry": {
                    "coordinates": [
                        [
                            -2.677815,
                            51.697084
                        ],
                        [
                            -2.678239,
                            51.69652
                        ],
                        [
                            -2.679275,
                            51.696692
                        ],
                        [
                            -2.678481,
                            51.695375
                        ],
                        [
                            -2.684634,
                            51.68979
                        ],
                        [
                            -2.687462,
                            51.687665
                        ],
                        [
                            -2.689847,
                            51.686478
                        ],
                        [
                            -2.695888,
                            51.677819
                        ],
                        [
                            -2.701028,
                            51.668765
                        ],
                        [
                            -2.700347,
                            51.667623
                        ],
                        [
                            -2.701488,
                            51.666864
                        ],
                        [
                            -2.700917,
                            51.666457
                        ],
                        [
                            -2.701434,
                            51.666209
                        ],
                        [
                            -2.701115,
                            51.665869
                        ],
                        [
                            -2.70158,
                            51.665605
                        ],
                        [
                            -2.701335,
                            51.665398
                        ],
                        [
                            -2.705639,
                            51.664425
                        ],
                        [
                            -2.71258,
                            51.661639
                        ],
                        [
                            -2.71252,
                            51.661284
                        ],
                        [
                            -2.721389,
                            51.65544
                        ],
                        [
                            -2.73551,
                            51.65069
                        ],
                        [
                            -2.735753,
                            51.650049
                        ],
                        [
                            -2.740983,
                            51.64548
                        ],
                        [
                            -2.745074,
                            51.644037
                        ],
                        [
                            -2.75086,
                            51.639664
                        ],
                        [
                            -2.753593,
                            51.639228
                        ],
                        [
                            -2.754063,
                            51.638838
                        ],
                        [
                            -2.753491,
                            51.638501
                        ],
                        [
                            -2.75356,
                            51.638342
                        ],
                        [
                            -2.76094,
                            51.637218
                        ],
                        [
                            -2.770196,
                            51.632871
                        ],
                        [
                            -2.776836,
                            51.632175
                        ],
                        [
                            -2.783192,
                            51.63082
                        ],
                        [
                            -2.783329,
                            51.630778
                        ],
                        [
                            -2.788494,
                            51.628004
                        ],
                        [
                            -2.795563,
                            51.626631
                        ],
                        [
                            -2.799052,
                            51.626853
                        ],
                        [
                            -2.811082,
                            51.627293
                        ],
                        [
                            -2.815942,
                            51.623461
                        ],
                        [
                            -2.818651,
                            51.621886
                        ],
                        [
                            -2.826539,
                            51.617985
                        ],
                        [
                            -2.827097,
                            51.616786
                        ],
                        [
                            -2.830664,
                            51.614905
                        ],
                        [
                            -2.830651,
                            51.61483
                        ],
                        [
                            -2.839201,
                            51.615437
                        ],
                        [
                            -2.900618,
                            51.606814
                        ],
                        [
                            -2.905974,
                            51.604185
                        ],
                        [
                            -2.906023,
                            51.604222
                        ],
                        [
                            -2.919957,
                            51.603883
                        ],
                        [
                            -2.920261,
                            51.603857
                        ],
                        [
                            -2.925947,
                            51.60156
                        ],
                        [
                            -2.926225,
                            51.601602
                        ],
                        [
                            -2.926021,
                            51.601328
                        ],
                        [
                            -2.959939,
                            51.588294
                        ],
                        [
                            -2.961273,
                            51.585971
                        ],
                        [
                            -2.962965,
                            51.586077
                        ],
                        [
                            -2.962942,
                            51.58292
                        ],
                        [
                            -2.963032,
                            51.582809
                        ],
                        [
                            -2.964182,
                            51.58279
                        ],
                        [
                            -2.964735,
                            51.579986
                        ],
                        [
                            -2.965586,
                            51.579862
                        ],
                        [
                            -2.967913,
                            51.579048
                        ],
                        [
                            -2.96866,
                            51.578434
                        ],
                        [
                            -2.968484,
                            51.577814
                        ],
                        [
                            -2.970581,
                            51.576997
                        ],
                        [
                            -2.979254,
                            51.576205
                        ],
                        [
                            -2.979642,
                            51.576055
                        ],
                        [
                            -2.979609,
                            51.575894
                        ],
                        [
                            -2.98242,
                            51.574922
                        ],
                        [
                            -2.982394,
                            51.574871
                        ],
                        [
                            -2.987333,
                            51.571209
                        ],
                        [
                            -2.987498,
                            51.571076
                        ],
                        [
                            -2.987592,
                            51.5711
                        ],
                        [
                            -3.003508,
                            51.567421
                        ],
                        [
                            -3.003626,
                            51.567368
                        ],
                        [
                            -3.004097,
                            51.567424
                        ],
                        [
                            -3.008318,
                            51.566064
                        ],
                        [
                            -3.009106,
                            51.56584
                        ],
                        [
                            -3.020053,
                            51.567679
                        ],
                        [
                            -3.032344,
                            51.566955
                        ],
                        [
                            -3.035133,
                            51.564591
                        ],
                        [
                            -3.04084,
                            51.556744
                        ],
                        [
                            -3.041201,
                            51.556435
                        ],
                        [
                            -3.045278,
                            51.554854
                        ],
                        [
                            -3.046062,
                            51.554791
                        ],
                        [
                            -3.055219,
                            51.553299
                        ],
                        [
                            -3.061554,
                            51.55149
                        ],
                        [
                            -3.067298,
                            51.550301
                        ],
                        [
                            -3.075952,
                            51.547717
                        ],
                        [
                            -3.07778,
                            51.546453
                        ],
                        [
                            -3.09515,
                            51.533991
                        ],
                        [
                            -3.099947,
                            51.531097
                        ],
                        [
                            -3.102959,
                            51.529636
                        ],
                        [
                            -3.108175,
                            51.527324
                        ],
                        [
                            -3.108838,
                            51.526899
                        ],
                        [
                            -3.10893,
                            51.526892
                        ],
                        [
                            -3.128089,
                            51.511036
                        ],
                        [
                            -3.132982,
                            51.508329
                        ],
                        [
                            -3.139662,
                            51.500763
                        ],
                        [
                            -3.140193,
                            51.499986
                        ],
                        [
                            -3.141621,
                            51.497439
                        ],
                        [
                            -3.141662,
                            51.497419
                        ],
                        [
                            -3.149665,
                            51.491373
                        ],
                        [
                            -3.149825,
                            51.491294
                        ],
                        [
                            -3.150791,
                            51.490739
                        ],
                        [
                            -3.160653,
                            51.486646
                        ],
                        [
                            -3.171362,
                            51.483142
                        ],
                        [
                            -3.171425,
                            51.483035
                        ],
                        [
                            -3.178975,
                            51.481557
                        ],
                        [
                            -3.179077,
                            51.481606
                        ],
                        [
                            -3.179375,
                            51.481674
                        ],
                        [
                            -3.180747,
                            51.481331
                        ],
                        [
                            -3.181046,
                            51.482255
                        ],
                        [
                            -3.180747,
                            51.481331
                        ],
                        [
                            -3.183453,
                            51.48108
                        ],
                        [
                            -3.183451,
                            51.48106
                        ],
                        [
                            -3.18469,
                            51.481071
                        ],
                        [
                            -3.184689,
                            51.481047
                        ],
                        [
                            -3.192487,
                            51.481075
                        ],
                        [
                            -3.192742,
                            51.481067
                        ],
                        [
                            -3.219228,
                            51.482986
                        ],
                        [
                            -3.219453,
                            51.482999
                        ],
                        [
                            -3.219596,
                            51.483056
                        ],
                        [
                            -3.226814,
                            51.484573
                        ],
                        [
                            -3.228086,
                            51.484905
                        ],
                        [
                            -3.228122,
                            51.48486
                        ],
                        [
                            -3.229897,
                            51.484777
                        ],
                        [
                            -3.229969,
                            51.48486
                        ],
                        [
                            -3.259175,
                            51.471428
                        ],
                        [
                            -3.266619,
                            51.46795
                        ],
                        [
                            -3.270455,
                            51.466536
                        ],
                        [
                            -3.271683,
                            51.465897
                        ],
                        [
                            -3.272488,
                            51.465517
                        ],
                        [
                            -3.272538,
                            51.465318
                        ],
                        [
                            -3.285078,
                            51.465118
                        ],
                        [
                            -3.331491,
                            51.459175
                        ],
                        [
                            -3.361126,
                            51.456645
                        ],
                        [
                            -3.378877,
                            51.45876
                        ],
                        [
                            -3.418499,
                            51.457636
                        ],
                        [
                            -3.467117,
                            51.466193
                        ],
                        [
                            -3.467798,
                            51.466491
                        ],
                        [
                            -3.468139,
                            51.466463
                        ],
                        [
                            -3.532689,
                            51.481451
                        ],
                        [
                            -3.545273,
                            51.484424
                        ],
                        [
                            -3.580891,
                            51.484473
                        ],
                        [
                            -3.582587,
                            51.48348
                        ],
                        [
                            -3.594009,
                            51.482249
                        ],
                        [
                            -3.60548,
                            51.48141
                        ],
                        [
                            -3.60612,
                            51.482212
                        ],
                        [
                            -3.609305,
                            51.484019
                        ],
                        [
                            -3.608541,
                            51.485135
                        ],
                        [
                            -3.61762,
                            51.485361
                        ],
                        [
                            -3.629132,
                            51.488482
                        ],
                        [
                            -3.634544,
                            51.488056
                        ],
                        [
                            -3.669742,
                            51.483782
                        ],
                        [
                            -3.670415,
                            51.483377
                        ],
                        [
                            -3.670747,
                            51.483799
                        ],
                        [
                            -3.674846,
                            51.483783
                        ],
                        [
                            -3.674968,
                            51.483779
                        ],
                        [
                            -3.677594,
                            51.484356
                        ],
                        [
                            -3.677954,
                            51.484228
                        ],
                        [
                            -3.679154,
                            51.483628
                        ],
                        [
                            -3.679311,
                            51.483795
                        ],
                        [
                            -3.686075,
                            51.486537
                        ],
                        [
                            -3.686036,
                            51.486984
                        ],
                        [
                            -3.696462,
                            51.488732
                        ],
                        [
                            -3.697148,
                            51.488723
                        ],
                        [
                            -3.697411,
                            51.488608
                        ],
                        [
                            -3.697937,
                            51.489048
                        ],
                        [
                            -3.701096,
                            51.489566
                        ],
                        [
                            -3.701628,
                            51.489962
                        ],
                        [
                            -3.701919,
                            51.489777
                        ],
                        [
                            -3.703029,
                            51.489837
                        ],
                        [
                            -3.711281,
                            51.488496
                        ],
                        [
                            -3.711416,
                            51.488762
                        ],
                        [
                            -3.71378,
                            51.488183
                        ],
                        [
                            -3.716848,
                            51.488357
                        ],
                        [
                            -3.718498,
                            51.488764
                        ],
                        [
                            -3.71971,
                            51.489449
                        ],
                        [
                            -3.720122,
                            51.489538
                        ],
                        [
                            -3.720352,
                            51.489871
                        ],
                        [
                            -3.723705,
                            51.489356
                        ],
                        [
                            -3.723539,
                            51.489119
                        ],
                        [
                            -3.723705,
                            51.489356
                        ],
                        [
                            -3.7159,
                            51.490988
                        ],
                        [
                            -3.714137,
                            51.492635
                        ],
                        [
                            -3.714385,
                            51.493388
                        ],
                        [
                            -3.711402,
                            51.494432
                        ],
                        [
                            -3.717287,
                            51.507138
                        ],
                        [
                            -3.714827,
                            51.526519
                        ],
                        [
                            -3.730495,
                            51.556273
                        ],
                        [
                            -3.736891,
                            51.561124
                        ],
                        [
                            -3.740134,
                            51.562097
                        ],
                        [
                            -3.743618,
                            51.565485
                        ],
                        [
                            -3.747519,
                            51.569207
                        ],
                        [
                            -3.747826,
                            51.569044
                        ],
                        [
                            -3.748238,
                            51.569314
                        ],
                        [
                            -3.757507,
                            51.574019
                        ],
                        [
                            -3.779919,
                            51.591797
                        ],
                        [
                            -3.779942,
                            51.591896
                        ],
                        [
                            -3.780512,
                            51.592854
                        ],
                        [
                            -3.780615,
                            51.592855
                        ],
                        [
                            -3.783743,
                            51.596561
                        ],
                        [
                            -3.782649,
                            51.597287
                        ],
                        [
                            -3.782733,
                            51.597885
                        ],
                        [
                            -3.782702,
                            51.597916
                        ],
                        [
                            -3.784523,
                            51.598194
                        ],
                        [
                            -3.785158,
                            51.598152
                        ],
                        [
                            -3.78549,
                            51.598294
                        ],
                        [
                            -3.787023,
                            51.598977
                        ],
                        [
                            -3.8015,
                            51.610724
                        ],
                        [
                            -3.807443,
                            51.615601
                        ],
                        [
                            -3.80841,
                            51.616171
                        ],
                        [
                            -3.808871,
                            51.61603
                        ],
                        [
                            -3.815234,
                            51.62079
                        ],
                        [
                            -3.815308,
                            51.620746
                        ],
                        [
                            -3.821674,
                            51.62896
                        ],
                        [
                            -3.837572,
                            51.629411
                        ],
                        [
                            -3.837733,
                            51.629433
                        ],
                        [
                            -3.853217,
                            51.624743
                        ],
                        [
                            -3.853971,
                            51.624631
                        ],
                        [
                            -3.933823,
                            51.621861
                        ],
                        [
                            -3.944909,
                            51.615757
                        ],
                        [
                            -3.945633,
                            51.61553
                        ],
                        [
                            -3.945748,
                            51.615333
                        ],
                        [
                            -3.961132,
                            51.612185
                        ],
                        [
                            -3.972544,
                            51.609686
                        ],
                        [
                            -3.972474,
                            51.609571
                        ],
                        [
                            -3.982082,
                            51.606064
                        ],
                        [
                            -3.992914,
                            51.599138
                        ],
                        [
                            -3.993359,
                            51.598881
                        ],
                        [
                            -3.995033,
                            51.596304
                        ],
                        [
                            -3.992056,
                            51.572886
                        ],
                        [
                            -3.99208,
                            51.572761
                        ],
                        [
                            -3.991876,
                            51.572708
                        ],
                        [
                            -3.989249,
                            51.571952
                        ],
                        [
                            -3.988491,
                            51.571713
                        ],
                        [
                            -3.98443,
                            51.570505
                        ],
                        [
                            -3.980073,
                            51.569584
                        ],
                        [
                            -3.977779,
                            51.569108
                        ],
                        [
                            -3.980073,
                            51.569584
                        ],
                        [
                            -3.98443,
                            51.570505
                        ],
                        [
                            -3.988491,
                            51.571713
                        ],
                        [
                            -3.99887,
                            51.575862
                        ],
                        [
                            -4.014778,
                            51.575154
                        ],
                        [
                            -4.015346,
                            51.574903
                        ],
                        [
                            -4.017118,
                            51.575827
                        ],
                        [
                            -4.033124,
                            51.580053
                        ],
                        [
                            -4.042565,
                            51.582887
                        ],
                        [
                            -4.042695,
                            51.583179
                        ],
                        [
                            -4.044176,
                            51.585518
                        ],
                        [
                            -4.051918,
                            51.586661
                        ],
                        [
                            -4.05197,
                            51.586593
                        ],
                        [
                            -4.055175,
                            51.584873
                        ],
                        [
                            -4.058263,
                            51.584729
                        ],
                        [
                            -4.059296,
                            51.584483
                        ],
                        [
                            -4.060376,
                            51.585256
                        ],
                        [
                            -4.060879,
                            51.585172
                        ],
                        [
                            -4.068479,
                            51.58669
                        ],
                        [
                            -4.074596,
                            51.585546
                        ],
                        [
                            -4.120002,
                            51.577724
                        ],
                        [
                            -4.127556,
                            51.575689
                        ],
                        [
                            -4.218739,
                            51.578427
                        ],
                        [
                            -4.2189,
                            51.578315
                        ],
                        [
                            -4.221532,
                            51.5735
                        ],
                        [
                            -4.22162,
                            51.573638
                        ],
                        [
                            -4.221972,
                            51.573735
                        ],
                        [
                            -4.235494,
                            51.570229
                        ],
                        [
                            -4.235512,
                            51.570165
                        ],
                        [
                            -4.254129,
                            51.56508
                        ],
                        [
                            -4.270029,
                            51.566547
                        ],
                        [
                            -4.278721,
                            51.56713
                        ],
                        [
                            -4.28133,
                            51.566573
                        ],
                        [
                            -4.283712,
                            51.565158
                        ],
                        [
                            -4.288598,
                            51.563691
                        ],
                        [
                            -4.289074,
                            51.563342
                        ],
                        [
                            -4.289114,
                            51.563365
                        ],
                        [
                            -4.291874,
                            51.563078
                        ],
                        [
                            -4.289114,
                            51.563365
                        ],
                        [
                            -4.289074,
                            51.563342
                        ],
                        [
                            -4.288598,
                            51.563691
                        ],
                        [
                            -4.283712,
                            51.565158
                        ],
                        [
                            -4.278721,
                            51.56713
                        ],
                        [
                            -4.278364,
                            51.567093
                        ],
                        [
                            -4.270943,
                            51.57243
                        ],
                        [
                            -4.270885,
                            51.573275
                        ],
                        [
                            -4.261334,
                            51.58003
                        ],
                        [
                            -4.261877,
                            51.589842
                        ],
                        [
                            -4.259886,
                            51.58988
                        ],
                        [
                            -4.257922,
                            51.589606
                        ],
                        [
                            -4.254882,
                            51.59263
                        ],
                        [
                            -4.245732,
                            51.599309
                        ],
                        [
                            -4.245149,
                            51.59951
                        ],
                        [
                            -4.2136,
                            51.602703
                        ],
                        [
                            -4.212681,
                            51.60479
                        ],
                        [
                            -4.102879,
                            51.641741
                        ],
                        [
                            -4.058598,
                            51.65002
                        ],
                        [
                            -4.052687,
                            51.649798
                        ],
                        [
                            -4.055242,
                            51.655205
                        ],
                        [
                            -4.064757,
                            51.659605
                        ],
                        [
                            -4.071229,
                            51.660767
                        ],
                        [
                            -4.072341,
                            51.66153
                        ],
                        [
                            -4.072007,
                            51.661901
                        ],
                        [
                            -4.075676,
                            51.662982
                        ],
                        [
                            -4.079558,
                            51.662402
                        ],
                        [
                            -4.079711,
                            51.662381
                        ],
                        [
                            -4.089323,
                            51.664011
                        ],
                        [
                            -4.090069,
                            51.66399
                        ],
                        [
                            -4.098577,
                            51.665608
                        ],
                        [
                            -4.103701,
                            51.666592
                        ],
                        [
                            -4.109062,
                            51.667861
                        ],
                        [
                            -4.110363,
                            51.66813
                        ],
                        [
                            -4.120109,
                            51.673213
                        ],
                        [
                            -4.127944,
                            51.677356
                        ],
                        [
                            -4.130622,
                            51.678294
                        ],
                        [
                            -4.13152,
                            51.678848
                        ],
                        [
                            -4.131431,
                            51.679935
                        ],
                        [
                            -4.13162,
                            51.68007
                        ],
                        [
                            -4.13136,
                            51.681294
                        ],
                        [
                            -4.131143,
                            51.681703
                        ],
                        [
                            -4.128209,
                            51.680605
                        ],
                        [
                            -4.128562,
                            51.680027
                        ],
                        [
                            -4.128446,
                            51.678217
                        ],
                        [
                            -4.128209,
                            51.680605
                        ],
                        [
                            -4.131232,
                            51.681778
                        ],
                        [
                            -4.131337,
                            51.681732
                        ],
                        [
                            -4.133356,
                            51.681636
                        ],
                        [
                            -4.133498,
                            51.68239
                        ],
                        [
                            -4.133653,
                            51.682479
                        ],
                        [
                            -4.133612,
                            51.682611
                        ],
                        [
                            -4.146041,
                            51.685912
                        ],
                        [
                            -4.148054,
                            51.686309
                        ],
                        [
                            -4.14834,
                            51.686288
                        ],
                        [
                            -4.150463,
                            51.685925
                        ],
                        [
                            -4.151328,
                            51.68681
                        ],
                        [
                            -4.154159,
                            51.685834
                        ],
                        [
                            -4.15489,
                            51.685704
                        ],
                        [
                            -4.154753,
                            51.685861
                        ],
                        [
                            -4.156722,
                            51.685731
                        ],
                        [
                            -4.156734,
                            51.686265
                        ],
                        [
                            -4.159511,
                            51.687507
                        ],
                        [
                            -4.159992,
                            51.687148
                        ],
                        [
                            -4.161842,
                            51.68771
                        ],
                        [
                            -4.162985,
                            51.687163
                        ],
                        [
                            -4.226136,
                            51.713338
                        ],
                        [
                            -4.242794,
                            51.720727
                        ],
                        [
                            -4.296506,
                            51.733499
                        ],
                        [
                            -4.295929,
                            51.734114
                        ],
                        [
                            -4.303633,
                            51.736937
                        ],
                        [
                            -4.307164,
                            51.736316
                        ],
                        [
                            -4.308763,
                            51.738332
                        ],
                        [
                            -4.306499,
                            51.739094
                        ],
                        [
                            -4.305814,
                            51.739057
                        ],
                        [
                            -4.306499,
                            51.739094
                        ],
                        [
                            -4.307367,
                            51.739689
                        ],
                        [
                            -4.307509,
                            51.739897
                        ],
                        [
                            -4.314339,
                            51.741957
                        ],
                        [
                            -4.369035,
                            51.76774
                        ],
                        [
                            -4.370295,
                            51.768285
                        ],
                        [
                            -4.370592,
                            51.768266
                        ],
                        [
                            -4.38823,
                            51.768323
                        ],
                        [
                            -4.38839,
                            51.76831
                        ],
                        [
                            -4.38843,
                            51.768382
                        ],
                        [
                            -4.388723,
                            51.768798
                        ],
                        [
                            -4.39145,
                            51.76901
                        ],
                        [
                            -4.392301,
                            51.771223
                        ],
                        [
                            -4.39215,
                            51.771286
                        ],
                        [
                            -4.404258,
                            51.773904
                        ],
                        [
                            -4.413256,
                            51.786152
                        ],
                        [
                            -4.414008,
                            51.787127
                        ],
                        [
                            -4.414829,
                            51.787322
                        ],
                        [
                            -4.423057,
                            51.788279
                        ],
                        [
                            -4.429939,
                            51.791889
                        ],
                        [
                            -4.469354,
                            51.803635
                        ],
                        [
                            -4.468263,
                            51.825859
                        ],
                        [
                            -4.471735,
                            51.825212
                        ],
                        [
                            -4.471763,
                            51.825257
                        ],
                        [
                            -4.490138,
                            51.820359
                        ],
                        [
                            -4.494442,
                            51.81859
                        ],
                        [
                            -4.498038,
                            51.818095
                        ],
                        [
                            -4.49758,
                            51.808404
                        ],
                        [
                            -4.503871,
                            51.805086
                        ],
                        [
                            -4.576298,
                            51.75261
                        ],
                        [
                            -4.663229,
                            51.73155
                        ],
                        [
                            -4.663628,
                            51.731535
                        ],
                        [
                            -4.663759,
                            51.731557
                        ],
                        [
                            -4.66751,
                            51.730876
                        ],
                        [
                            -4.682825,
                            51.726741
                        ],
                        [
                            -4.694313,
                            51.716948
                        ],
                        [
                            -4.695309,
                            51.716288
                        ],
                        [
                            -4.695419,
                            51.714773
                        ],
                        [
                            -4.698943,
                            51.711608
                        ],
                        [
                            -4.700722,
                            51.70424
                        ],
                        [
                            -4.708771,
                            51.697841
                        ],
                        [
                            -4.70832,
                            51.690237
                        ],
                        [
                            -4.70937,
                            51.687383
                        ],
                        [
                            -4.709025,
                            51.685377
                        ],
                        [
                            -4.704609,
                            51.677499
                        ],
                        [
                            -4.704192,
                            51.677233
                        ],
                        [
                            -4.700706,
                            51.672712
                        ],
                        [
                            -4.698386,
                            51.67194
                        ],
                        [
                            -4.697469,
                            51.671883
                        ],
                        [
                            -4.696372,
                            51.672164
                        ],
                        [
                            -4.696311,
                            51.672151
                        ],
                        [
                            -4.695665,
                            51.672266
                        ],
                        [
                            -4.695448,
                            51.672274
                        ],
                        [
                            -4.695667,
                            51.672424
                        ],
                        [
                            -4.695088,
                            51.672563
                        ],
                        [
                            -4.694858,
                            51.672419
                        ],
                        [
                            -4.694457,
                            51.672352
                        ],
                        [
                            -4.694551,
                            51.672135
                        ],
                        [
                            -4.693873,
                            51.672112
                        ],
                        [
                            -4.693686,
                            51.672046
                        ],
                        [
                            -4.693873,
                            51.672112
                        ],
                        [
                            -4.694082,
                            51.672076
                        ],
                        [
                            -4.694705,
                            51.672023
                        ],
                        [
                            -4.699284,
                            51.669637
                        ],
                        [
                            -4.702332,
                            51.668836
                        ],
                        [
                            -4.703306,
                            51.668774
                        ],
                        [
                            -4.703887,
                            51.66879
                        ],
                        [
                            -4.706394,
                            51.669907
                        ],
                        [
                            -4.707419,
                            51.669901
                        ],
                        [
                            -4.712397,
                            51.665942
                        ],
                        [
                            -4.717148,
                            51.662848
                        ],
                        [
                            -4.733749,
                            51.656444
                        ],
                        [
                            -4.790078,
                            51.652546
                        ],
                        [
                            -4.806524,
                            51.656019
                        ],
                        [
                            -4.818103,
                            51.655801
                        ],
                        [
                            -4.81987,
                            51.6555
                        ],
                        [
                            -4.835501,
                            51.654512
                        ],
                        [
                            -4.865192,
                            51.649883
                        ],
                        [
                            -4.865259,
                            51.6498
                        ],
                        [
                            -4.866165,
                            51.649493
                        ],
                        [
                            -4.879686,
                            51.639938
                        ],
                        [
                            -4.880014,
                            51.639753
                        ],
                        [
                            -4.901766,
                            51.633131
                        ],
                        [
                            -4.90082,
                            51.624729
                        ],
                        [
                            -4.902604,
                            51.624846
                        ],
                        [
                            -4.901414,
                            51.62437
                        ],
                        [
                            -4.903263,
                            51.619624
                        ],
                        [
                            -4.901414,
                            51.62437
                        ],
                        [
                            -4.902604,
                            51.624846
                        ],
                        [
                            -4.90082,
                            51.624729
                        ],
                        [
                            -4.901766,
                            51.633131
                        ],
                        [
                            -4.908688,
                            51.632625
                        ],
                        [
                            -4.901572,
                            51.652094
                        ],
                        [
                            -4.911752,
                            51.658901
                        ],
                        [
                            -4.912383,
                            51.659022
                        ],
                        [
                            -4.907946,
                            51.663904
                        ],
                        [
                            -4.909424,
                            51.672503
                        ],
                        [
                            -4.91493,
                            51.674384
                        ],
                        [
                            -4.914549,
                            51.674458
                        ],
                        [
                            -4.914072,
                            51.6751
                        ],
                        [
                            -4.918215,
                            51.676196
                        ],
                        [
                            -4.921517,
                            51.685931
                        ],
                        [
                            -4.925563,
                            51.690614
                        ],
                        [
                            -4.948301,
                            51.692582
                        ],
                        [
                            -4.948341,
                            51.69256
                        ],
                        [
                            -4.952585,
                            51.693795
                        ],
                        [
                            -4.951933,
                            51.695865
                        ],
                        [
                            -4.953228,
                            51.69622
                        ],
                        [
                            -4.953057,
                            51.69828
                        ],
                        [
                            -5.093473,
                            51.696745
                        ],
                        [
                            -4.953057,
                            51.69828
                        ],
                        [
                            -4.953429,
                            51.698268
                        ],
                        [
                            -4.953147,
                            51.696889
                        ],
                        [
                            -4.953228,
                            51.69622
                        ],
                        [
                            -4.951933,
                            51.695865
                        ],
                        [
                            -4.952585,
                            51.693795
                        ],
                        [
                            -4.939595,
                            51.696214
                        ],
                        [
                            -4.939204,
                            51.695971
                        ],
                        [
                            -4.938951,
                            51.696095
                        ],
                        [
                            -4.938795,
                            51.696073
                        ],
                        [
                            -4.937165,
                            51.697917
                        ],
                        [
                            -4.931561,
                            51.701226
                        ],
                        [
                            -4.931194,
                            51.701148
                        ],
                        [
                            -4.931865,
                            51.703002
                        ],
                        [
                            -4.935785,
                            51.710397
                        ],
                        [
                            -4.946737,
                            51.716589
                        ],
                        [
                            -4.946722,
                            51.716647
                        ],
                        [
                            -4.946471,
                            51.718997
                        ],
                        [
                            -4.973228,
                            51.738848
                        ],
                        [
                            -4.998212,
                            51.750441
                        ],
                        [
                            -4.998079,
                            51.749977
                        ],
                        [
                            -5.021013,
                            51.755335
                        ],
                        [
                            -5.035073,
                            51.755912
                        ],
                        [
                            -5.034437,
                            51.756673
                        ],
                        [
                            -5.045322,
                            51.770152
                        ],
                        [
                            -5.045811,
                            51.77361
                        ],
                        [
                            -5.045076,
                            51.774542
                        ],
                        [
                            -5.046616,
                            51.793431
                        ],
                        [
                            -5.049182,
                            51.793232
                        ],
                        [
                            -5.06535,
                            51.796847
                        ],
                        [
                            -5.073043,
                            51.79882
                        ],
                        [
                            -5.074203,
                            51.803281
                        ],
                        [
                            -5.085323,
                            51.806557
                        ],
                        [
                            -5.085268,
                            51.806618
                        ],
                        [
                            -5.091926,
                            51.80774
                        ],
                        [
                            -5.10028,
                            51.8114
                        ],
                        [
                            -5.10066,
                            51.811536
                        ],
                        [
                            -5.106382,
                            51.824686
                        ],
                        [
                            -5.121304,
                            51.850843
                        ],
                        [
                            -5.127093,
                            51.858613
                        ],
                        [
                            -5.141672,
                            51.865349
                        ],
                        [
                            -5.141302,
                            51.86915
                        ],
                        [
                            -5.148612,
                            51.870659
                        ],
                        [
                            -5.187122,
                            51.875761
                        ],
                        [
                            -5.188986,
                            51.874569
                        ],
                        [
                            -5.191425,
                            51.873619
                        ],
                        [
                            -5.19771,
                            51.874233
                        ],
                        [
                            -5.20034,
                            51.874348
                        ],
                        [
                            -5.259489,
                            51.880805
                        ],
                        [
                            -5.259743,
                            51.880743
                        ],
                        [
                            -5.25984,
                            51.880692
                        ],
                        [
                            -5.259983,
                            51.880706
                        ],
                        [
                            -5.260046,
                            51.880765
                        ],
                        [
                            -5.265124,
                            51.880975
                        ],
                        [
                            -5.26721,
                            51.881414
                        ],
                        [
                            -5.267795,
                            51.881386
                        ],
                        [
                            -5.267988,
                            51.881502
                        ],
                        [
                            -5.26807,
                            51.88212
                        ],
                        [
                            -5.267838,
                            51.882671
                        ],
                        [
                            -5.267268,
                            51.882714
                        ],
                        [
                            -5.267115,
                            51.882726
                        ],
                        [
                            -5.266289,
                            51.882715
                        ],
                        [
                            -5.265526,
                            51.882441
                        ],
                        [
                            -5.264991,
                            51.882414
                        ],
                        [
                            -5.253114,
                            51.886541
                        ],
                        [
                            -5.180677,
                            51.91456
                        ],
                        [
                            -5.121563,
                            51.938695
                        ],
                        [
                            -5.111376,
                            51.945068
                        ],
                        [
                            -5.109763,
                            51.944998
                        ],
                        [
                            -5.080311,
                            51.961591
                        ],
                        [
                            -5.080043,
                            51.961558
                        ],
                        [
                            -5.078716,
                            51.96223
                        ],
                        [
                            -5.076115,
                            51.960572
                        ],
                        [
                            -5.070164,
                            51.968696
                        ],
                        [
                            -5.07183,
                            51.969343
                        ],
                        [
                            -5.06922,
                            51.972285
                        ],
                        [
                            -5.064862,
                            51.997279
                        ],
                        [
                            -5.066725,
                            51.999704
                        ],
                        [
                            -5.068159,
                            52.001085
                        ],
                        [
                            -5.062835,
                            52.007289
                        ],
                        [
                            -5.05711,
                            52.018149
                        ],
                        [
                            -5.05927,
                            52.020087
                        ],
                        [
                            -5.069777,
                            52.02945
                        ],
                        [
                            -5.070648,
                            52.029173
                        ],
                        [
                            -5.071999,
                            52.02916
                        ],
                        [
                            -5.072138,
                            52.02926
                        ],
                        [
                            -5.0725,
                            52.029436
                        ],
                        [
                            -5.073484,
                            52.029662
                        ],
                        [
                            -5.0725,
                            52.029436
                        ],
                        [
                            -5.072138,
                            52.02926
                        ],
                        [
                            -5.071999,
                            52.02916
                        ],
                        [
                            -5.070648,
                            52.029173
                        ],
                        [
                            -5.069777,
                            52.02945
                        ],
                        [
                            -5.05711,
                            52.018149
                        ],
                        [
                            -5.032994,
                            52.015249
                        ],
                        [
                            -5.023901,
                            52.007842
                        ],
                        [
                            -5.015417,
                            52.008358
                        ],
                        [
                            -5.007169,
                            52.007509
                        ],
                        [
                            -5.002827,
                            52.002542
                        ],
                        [
                            -5.00204,
                            52.00262
                        ],
                        [
                            -5.001407,
                            52.002721
                        ],
                        [
                            -5.000206,
                            52.003042
                        ],
                        [
                            -4.996792,
                            52.004417
                        ],
                        [
                            -4.995669,
                            52.004798
                        ],
                        [
                            -4.995031,
                            52.004964
                        ],
                        [
                            -4.993701,
                            52.003462
                        ],
                        [
                            -4.993439,
                            52.003383
                        ],
                        [
                            -4.993242,
                            52.003305
                        ],
                        [
                            -4.99294,
                            52.003401
                        ],
                        [
                            -4.991496,
                            52.00226
                        ],
                        [
                            -4.990697,
                            52.002035
                        ],
                        [
                            -4.989957,
                            52.000692
                        ],
                        [
                            -4.988339,
                            51.999551
                        ],
                        [
                            -4.988218,
                            51.999037
                        ],
                        [
                            -4.987841,
                            51.998697
                        ],
                        [
                            -4.987306,
                            51.998548
                        ],
                        [
                            -4.987163,
                            51.99851
                        ],
                        [
                            -4.987139,
                            51.998404
                        ],
                        [
                            -4.978284,
                            51.994807
                        ],
                        [
                            -4.97688,
                            51.99509
                        ],
                        [
                            -4.97529,
                            51.995357
                        ],
                        [
                            -4.973426,
                            51.995544
                        ],
                        [
                            -4.972316,
                            51.995317
                        ],
                        [
                            -4.968076,
                            51.995089
                        ],
                        [
                            -4.968227,
                            51.996109
                        ],
                        [
                            -4.966465,
                            51.997016
                        ],
                        [
                            -4.950685,
                            51.998002
                        ],
                        [
                            -4.835578,
                            52.015687
                        ],
                        [
                            -4.810665,
                            52.016509
                        ],
                        [
                            -4.810405,
                            52.019572
                        ],
                        [
                            -4.795694,
                            52.02348
                        ],
                        [
                            -4.791093,
                            52.02383
                        ],
                        [
                            -4.691532,
                            52.05382
                        ],
                        [
                            -4.681619,
                            52.06472
                        ],
                        [
                            -4.668109,
                            52.069765
                        ],
                        [
                            -4.668922,
                            52.072174
                        ],
                        [
                            -4.665692,
                            52.075828
                        ],
                        [
                            -4.665408,
                            52.076098
                        ],
                        [
                            -4.661196,
                            52.079752
                        ],
                        [
                            -4.660329,
                            52.079946
                        ],
                        [
                            -4.660799,
                            52.081033
                        ],
                        [
                            -4.661322,
                            52.081695
                        ],
                        [
                            -4.660891,
                            52.081576
                        ],
                        [
                            -4.660594,
                            52.08168
                        ],
                        [
                            -4.660522,
                            52.081967
                        ],
                        [
                            -4.660594,
                            52.08168
                        ],
                        [
                            -4.660891,
                            52.081576
                        ],
                        [
                            -4.661322,
                            52.081695
                        ],
                        [
                            -4.656512,
                            52.086423
                        ],
                        [
                            -4.645349,
                            52.089832
                        ],
                        [
                            -4.644784,
                            52.089723
                        ],
                        [
                            -4.611058,
                            52.101542
                        ],
                        [
                            -4.583156,
                            52.108073
                        ],
                        [
                            -4.570303,
                            52.111397
                        ],
                        [
                            -4.5294,
                            52.11063
                        ],
                        [
                            -4.523997,
                            52.111775
                        ],
                        [
                            -4.467563,
                            52.130246
                        ],
                        [
                            -4.361428,
                            52.151536
                        ],
                        [
                            -4.307608,
                            52.193937
                        ],
                        [
                            -4.271657,
                            52.225261
                        ],
                        [
                            -4.271328,
                            52.225813
                        ],
                        [
                            -4.270283,
                            52.226897
                        ],
                        [
                            -4.258794,
                            52.235606
                        ],
                        [
                            -4.258071,
                            52.237832
                        ],
                        [
                            -4.256436,
                            52.242143
                        ],
                        [
                            -4.254852,
                            52.244416
                        ],
                        [
                            -4.249428,
                            52.245122
                        ],
                        [
                            -4.230327,
                            52.25057
                        ],
                        [
                            -4.133413,
                            52.313845
                        ],
                        [
                            -4.132474,
                            52.317284
                        ],
                        [
                            -4.091227,
                            52.359564
                        ],
                        [
                            -4.079262,
                            52.375631
                        ],
                        [
                            -4.070831,
                            52.400213
                        ],
                        [
                            -4.070713,
                            52.400277
                        ],
                        [
                            -4.065783,
                            52.404351
                        ],
                        [
                            -4.065632,
                            52.404491
                        ],
                        [
                            -4.064396,
                            52.404587
                        ],
                        [
                            -4.060077,
                            52.407726
                        ],
                        [
                            -4.059497,
                            52.407919
                        ],
                        [
                            -4.059585,
                            52.408472
                        ],
                        [
                            -4.060116,
                            52.408451
                        ],
                        [
                            -4.061348,
                            52.408994
                        ],
                        [
                            -4.061308,
                            52.409038
                        ],
                        [
                            -4.061348,
                            52.408994
                        ],
                        [
                            -4.061434,
                            52.409017
                        ],
                        [
                            -4.060631,
                            52.409759
                        ],
                        [
                            -4.059133,
                            52.409754
                        ],
                        [
                            -4.058971,
                            52.409595
                        ],
                        [
                            -4.057657,
                            52.409912
                        ],
                        [
                            -4.044798,
                            52.414495
                        ],
                        [
                            -4.041889,
                            52.416691
                        ],
                        [
                            -4.036695,
                            52.423866
                        ],
                        [
                            -4.033074,
                            52.428084
                        ],
                        [
                            -4.019276,
                            52.453496
                        ],
                        [
                            -3.982593,
                            52.483646
                        ],
                        [
                            -3.982973,
                            52.493173
                        ],
                        [
                            -3.978907,
                            52.503508
                        ],
                        [
                            -3.978705,
                            52.506032
                        ],
                        [
                            -3.977698,
                            52.509929
                        ],
                        [
                            -3.975713,
                            52.512355
                        ],
                        [
                            -3.975375,
                            52.512906
                        ],
                        [
                            -3.970725,
                            52.518802
                        ],
                        [
                            -3.937453,
                            52.543001
                        ],
                        [
                            -3.93253,
                            52.551643
                        ],
                        [
                            -3.92496,
                            52.555193
                        ],
                        [
                            -3.922271,
                            52.556576
                        ],
                        [
                            -3.912468,
                            52.563146
                        ],
                        [
                            -3.886714,
                            52.574668
                        ],
                        [
                            -3.857567,
                            52.586885
                        ],
                        [
                            -3.85751,
                            52.587
                        ],
                        [
                            -3.857276,
                            52.586972
                        ],
                        [
                            -3.853329,
                            52.590457
                        ],
                        [
                            -3.852711,
                            52.591763
                        ],
                        [
                            -3.855221,
                            52.594138
                        ],
                        [
                            -3.855641,
                            52.600137
                        ],
                        [
                            -3.848606,
                            52.600788
                        ],
                        [
                            -3.848035,
                            52.601353
                        ],
                        [
                            -3.844569,
                            52.605166
                        ],
                        [
                            -3.845643,
                            52.60411
                        ],
                        [
                            -3.85576,
                            52.6008
                        ],
                        [
                            -3.859689,
                            52.600251
                        ],
                        [
                            -3.872526,
                            52.594636
                        ],
                        [
                            -3.882978,
                            52.589919
                        ],
                        [
                            -3.920785,
                            52.585463
                        ],
                        [
                            -3.937415,
                            52.58289
                        ],
                        [
                            -3.94325,
                            52.582433
                        ],
                        [
                            -4.053362,
                            52.605383
                        ],
                        [
                            -4.055332,
                            52.60619
                        ],
                        [
                            -4.055854,
                            52.609891
                        ],
                        [
                            -4.083783,
                            52.628813
                        ],
                        [
                            -4.088396,
                            52.644322
                        ],
                        [
                            -4.088352,
                            52.64438
                        ],
                        [
                            -4.083891,
                            52.652072
                        ],
                        [
                            -4.085043,
                            52.664023
                        ],
                        [
                            -4.08449,
                            52.665425
                        ],
                        [
                            -4.084031,
                            52.665807
                        ],
                        [
                            -4.045438,
                            52.695432
                        ],
                        [
                            -4.039325,
                            52.699618
                        ],
                        [
                            -4.029433,
                            52.70232
                        ],
                        [
                            -4.030513,
                            52.706893
                        ],
                        [
                            -4.030406,
                            52.706951
                        ],
                        [
                            -4.031435,
                            52.708111
                        ],
                        [
                            -4.047069,
                            52.720008
                        ],
                        [
                            -4.051146,
                            52.719968
                        ],
                        [
                            -4.051843,
                            52.719198
                        ],
                        [
                            -4.052241,
                            52.719307
                        ],
                        [
                            -4.052533,
                            52.719312
                        ],
                        [
                            -4.052911,
                            52.71915
                        ],
                        [
                            -4.053238,
                            52.718826
                        ],
                        [
                            -4.057069,
                            52.72129
                        ],
                        [
                            -4.060651,
                            52.723076
                        ],
                        [
                            -4.063586,
                            52.724914
                        ],
                        [
                            -4.064225,
                            52.725589
                        ],
                        [
                            -4.070789,
                            52.734754
                        ],
                        [
                            -4.070174,
                            52.735292
                        ],
                        [
                            -4.07021,
                            52.736835
                        ],
                        [
                            -4.082992,
                            52.756915
                        ],
                        [
                            -4.085381,
                            52.763029
                        ],
                        [
                            -4.096409,
                            52.785533
                        ],
                        [
                            -4.096812,
                            52.788234
                        ],
                        [
                            -4.104053,
                            52.825005
                        ],
                        [
                            -4.114916,
                            52.840686
                        ],
                        [
                            -4.114521,
                            52.840725
                        ],
                        [
                            -4.107859,
                            52.856145
                        ],
                        [
                            -4.107316,
                            52.856776
                        ],
                        [
                            -4.10803,
                            52.857403
                        ],
                        [
                            -4.107716,
                            52.859245
                        ],
                        [
                            -4.108443,
                            52.859439
                        ],
                        [
                            -4.108157,
                            52.859869
                        ],
                        [
                            -4.108322,
                            52.8599
                        ],
                        [
                            -4.108311,
                            52.859939
                        ],
                        [
                            -4.108659,
                            52.859972
                        ],
                        [
                            -4.108895,
                            52.85996
                        ],
                        [
                            -4.108659,
                            52.859972
                        ],
                        [
                            -4.108311,
                            52.859939
                        ],
                        [
                            -4.108322,
                            52.8599
                        ],
                        [
                            -4.108157,
                            52.859869
                        ],
                        [
                            -4.108144,
                            52.859891
                        ],
                        [
                            -4.107671,
                            52.859897
                        ],
                        [
                            -4.107406,
                            52.860239
                        ],
                        [
                            -4.105565,
                            52.860433
                        ],
                        [
                            -4.07145,
                            52.893033
                        ],
                        [
                            -4.053072,
                            52.910746
                        ],
                        [
                            -4.051637,
                            52.91786
                        ],
                        [
                            -4.053098,
                            52.918477
                        ],
                        [
                            -4.053053,
                            52.918509
                        ],
                        [
                            -4.05788,
                            52.927757
                        ],
                        [
                            -4.057917,
                            52.927737
                        ],
                        [
                            -4.066475,
                            52.928771
                        ],
                        [
                            -4.068573,
                            52.928831
                        ],
                        [
                            -4.080374,
                            52.926633
                        ],
                        [
                            -4.081289,
                            52.926521
                        ],
                        [
                            -4.132911,
                            52.934476
                        ],
                        [
                            -4.133531,
                            52.934633
                        ],
                        [
                            -4.133772,
                            52.934711
                        ],
                        [
                            -4.148179,
                            52.938167
                        ],
                        [
                            -4.148529,
                            52.938744
                        ],
                        [
                            -4.148486,
                            52.93889
                        ],
                        [
                            -4.148869,
                            52.939048
                        ],
                        [
                            -4.162713,
                            52.943164
                        ],
                        [
                            -4.189705,
                            52.946273
                        ],
                        [
                            -4.257296,
                            52.967296
                        ],
                        [
                            -4.265096,
                            52.977171
                        ],
                        [
                            -4.265746,
                            52.977124
                        ],
                        [
                            -4.274652,
                            52.974412
                        ],
                        [
                            -4.307192,
                            52.973039
                        ],
                        [
                            -4.3121,
                            52.970193
                        ],
                        [
                            -4.3408,
                            52.967406
                        ],
                        [
                            -4.401158,
                            52.972412
                        ],
                        [
                            -4.402106,
                            52.975603
                        ],
                        [
                            -4.404582,
                            52.976653
                        ],
                        [
                            -4.432323,
                            52.962897
                        ],
                        [
                            -4.448776,
                            52.960582
                        ],
                        [
                            -4.457005,
                            52.975536
                        ],
                        [
                            -4.457851,
                            52.975424
                        ],
                        [
                            -4.458264,
                            52.975332
                        ],
                        [
                            -4.457851,
                            52.975424
                        ],
                        [
                            -4.453695,
                            52.967877
                        ],
                        [
                            -4.440201,
                            52.981828
                        ],
                        [
                            -4.432436,
                            52.988478
                        ],
                        [
                            -4.426431,
                            52.993025
                        ],
                        [
                            -4.421661,
                            52.995395
                        ],
                        [
                            -4.408223,
                            52.993146
                        ],
                        [
                            -4.400314,
                            52.998404
                        ],
                        [
                            -4.400233,
                            52.998356
                        ],
                        [
                            -4.36949,
                            53.016983
                        ],
                        [
                            -4.366567,
                            53.019499
                        ],
                        [
                            -4.364479,
                            53.021067
                        ],
                        [
                            -4.363708,
                            53.02194
                        ],
                        [
                            -4.36364,
                            53.021923
                        ],
                        [
                            -4.295788,
                            53.041708
                        ],
                        [
                            -4.286855,
                            53.041169
                        ],
                        [
                            -4.284377,
                            53.041015
                        ],
                        [
                            -4.28278,
                            53.043972
                        ],
                        [
                            -4.281884,
                            53.044358
                        ],
                        [
                            -4.248188,
                            53.049743
                        ],
                        [
                            -4.225611,
                            53.051454
                        ],
                        [
                            -4.225092,
                            53.051288
                        ],
                        [
                            -4.197481,
                            53.053281
                        ],
                        [
                            -4.190746,
                            53.054827
                        ],
                        [
                            -4.185123,
                            53.057084
                        ],
                        [
                            -4.18448,
                            53.057327
                        ],
                        [
                            -4.173263,
                            53.058315
                        ],
                        [
                            -4.13969,
                            53.051723
                        ],
                        [
                            -4.138418,
                            53.050417
                        ],
                        [
                            -4.136896,
                            53.050975
                        ],
                        [
                            -4.133842,
                            53.051289
                        ],
                        [
                            -4.10283,
                            53.011971
                        ],
                        [
                            -4.124017,
                            53.025436
                        ],
                        [
                            -4.141314,
                            53.071589
                        ],
                        [
                            -4.236603,
                            53.129739
                        ],
                        [
                            -4.237105,
                            53.129751
                        ],
                        [
                            -4.237196,
                            53.129713
                        ],
                        [
                            -4.237794,
                            53.129869
                        ],
                        [
                            -4.270649,
                            53.138848
                        ],
                        [
                            -4.270604,
                            53.13846
                        ],
                        [
                            -4.270825,
                            53.138892
                        ],
                        [
                            -4.270946,
                            53.138847
                        ],
                        [
                            -4.274538,
                            53.139505
                        ],
                        [
                            -4.274643,
                            53.139335
                        ],
                        [
                            -4.27565,
                            53.139635
                        ],
                        [
                            -4.275704,
                            53.139204
                        ],
                        [
                            -4.276922,
                            53.139061
                        ],
                        [
                            -4.275704,
                            53.139204
                        ],
                        [
                            -4.27565,
                            53.139635
                        ],
                        [
                            -4.274995,
                            53.140287
                        ],
                        [
                            -4.274434,
                            53.140854
                        ],
                        [
                            -4.27405,
                            53.140859
                        ],
                        [
                            -4.272138,
                            53.143796
                        ],
                        [
                            -4.272167,
                            53.143856
                        ],
                        [
                            -4.271859,
                            53.144106
                        ],
                        [
                            -4.270614,
                            53.145091
                        ],
                        [
                            -4.270325,
                            53.145451
                        ],
                        [
                            -4.270203,
                            53.145538
                        ],
                        [
                            -4.269605,
                            53.145911
                        ],
                        [
                            -4.269713,
                            53.146208
                        ],
                        [
                            -4.268796,
                            53.148101
                        ],
                        [
                            -4.264608,
                            53.152338
                        ],
                        [
                            -4.264522,
                            53.152299
                        ],
                        [
                            -4.231978,
                            53.170639
                        ],
                        [
                            -4.231941,
                            53.170596
                        ],
                        [
                            -4.209651,
                            53.183341
                        ],
                        [
                            -4.20003,
                            53.18891
                        ],
                        [
                            -4.196267,
                            53.191333
                        ],
                        [
                            -4.195618,
                            53.191491
                        ],
                        [
                            -4.184607,
                            53.195467
                        ],
                        [
                            -4.184665,
                            53.195524
                        ],
                        [
                            -4.182839,
                            53.196684
                        ],
                        [
                            -4.177044,
                            53.204046
                        ],
                        [
                            -4.176721,
                            53.204516
                        ],
                        [
                            -4.176667,
                            53.204562
                        ],
                        [
                            -4.173727,
                            53.207046
                        ],
                        [
                            -4.173598,
                            53.207079
                        ],
                        [
                            -4.173425,
                            53.207387
                        ],
                        [
                            -4.160561,
                            53.218496
                        ],
                        [
                            -4.161335,
                            53.218763
                        ],
                        [
                            -4.16178,
                            53.218751
                        ],
                        [
                            -4.16207,
                            53.219188
                        ],
                        [
                            -4.163368,
                            53.220529
                        ],
                        [
                            -4.165163,
                            53.222164
                        ],
                        [
                            -4.165409,
                            53.222428
                        ],
                        [
                            -4.165332,
                            53.222611
                        ],
                        [
                            -4.158578,
                            53.232427
                        ],
                        [
                            -4.145619,
                            53.237775
                        ],
                        [
                            -4.106441,
                            53.254416
                        ],
                        [
                            -4.08984,
                            53.264125
                        ],
                        [
                            -4.105429,
                            53.254857
                        ],
                        [
                            -4.128249,
                            53.24557
                        ],
                        [
                            -4.129204,
                            53.244944
                        ],
                        [
                            -4.141848,
                            53.239296
                        ],
                        [
                            -4.156747,
                            53.233534
                        ],
                        [
                            -4.165115,
                            53.222742
                        ],
                        [
                            -4.165332,
                            53.222611
                        ],
                        [
                            -4.165409,
                            53.222428
                        ],
                        [
                            -4.163653,
                            53.220818
                        ],
                        [
                            -4.16233,
                            53.219482
                        ],
                        [
                            -4.16178,
                            53.218751
                        ],
                        [
                            -4.161335,
                            53.218763
                        ],
                        [
                            -4.160807,
                            53.218919
                        ],
                        [
                            -4.160441,
                            53.219037
                        ],
                        [
                            -4.15961,
                            53.219414
                        ],
                        [
                            -4.157176,
                            53.220524
                        ],
                        [
                            -4.156113,
                            53.221275
                        ],
                        [
                            -4.154238,
                            53.222178
                        ],
                        [
                            -4.144432,
                            53.218864
                        ],
                        [
                            -4.143303,
                            53.219036
                        ],
                        [
                            -4.131614,
                            53.21658
                        ],
                        [
                            -4.124806,
                            53.217298
                        ],
                        [
                            -4.123687,
                            53.21561
                        ],
                        [
                            -4.101604,
                            53.216282
                        ],
                        [
                            -4.101785,
                            53.216802
                        ],
                        [
                            -4.101717,
                            53.216844
                        ],
                        [
                            -4.093106,
                            53.216408
                        ],
                        [
                            -4.082489,
                            53.218182
                        ],
                        [
                            -4.067793,
                            53.219655
                        ],
                        [
                            -4.067227,
                            53.219493
                        ],
                        [
                            -4.066455,
                            53.21949
                        ],
                        [
                            -3.997875,
                            53.244673
                        ],
                        [
                            -3.996511,
                            53.244533
                        ],
                        [
                            -3.979042,
                            53.253207
                        ],
                        [
                            -3.971852,
                            53.259715
                        ],
                        [
                            -3.967848,
                            53.262163
                        ],
                        [
                            -3.967308,
                            53.261912
                        ],
                        [
                            -3.96317,
                            53.263591
                        ],
                        [
                            -3.96229,
                            53.2638
                        ],
                        [
                            -3.94196,
                            53.266672
                        ],
                        [
                            -3.920539,
                            53.268364
                        ],
                        [
                            -3.908456,
                            53.272716
                        ],
                        [
                            -3.905534,
                            53.273975
                        ],
                        [
                            -3.889739,
                            53.271747
                        ],
                        [
                            -3.885949,
                            53.271362
                        ],
                        [
                            -3.832949,
                            53.279995
                        ],
                        [
                            -3.832432,
                            53.280182
                        ],
                        [
                            -3.83047,
                            53.280478
                        ],
                        [
                            -3.826854,
                            53.280609
                        ],
                        [
                            -3.826476,
                            53.280464
                        ],
                        [
                            -3.825502,
                            53.280437
                        ],
                        [
                            -3.825355,
                            53.280387
                        ],
                        [
                            -3.825502,
                            53.280437
                        ],
                        [
                            -3.814079,
                            53.284757
                        ],
                        [
                            -3.813659,
                            53.28482
                        ],
                        [
                            -3.813382,
                            53.284819
                        ],
                        [
                            -3.812982,
                            53.284798
                        ],
                        [
                            -3.812872,
                            53.284504
                        ],
                        [
                            -3.812759,
                            53.284536
                        ],
                        [
                            -3.81225,
                            53.284634
                        ],
                        [
                            -3.797409,
                            53.282601
                        ],
                        [
                            -3.796829,
                            53.282693
                        ],
                        [
                            -3.796616,
                            53.282615
                        ],
                        [
                            -3.792704,
                            53.281909
                        ],
                        [
                            -3.786676,
                            53.285718
                        ],
                        [
                            -3.773299,
                            53.291068
                        ],
                        [
                            -3.770517,
                            53.292382
                        ],
                        [
                            -3.762388,
                            53.29146
                        ],
                        [
                            -3.762497,
                            53.291335
                        ],
                        [
                            -3.762531,
                            53.290656
                        ],
                        [
                            -3.760796,
                            53.290238
                        ],
                        [
                            -3.744925,
                            53.293058
                        ],
                        [
                            -3.729085,
                            53.289958
                        ],
                        [
                            -3.719114,
                            53.28934
                        ],
                        [
                            -3.692711,
                            53.288378
                        ],
                        [
                            -3.664325,
                            53.28991
                        ],
                        [
                            -3.645306,
                            53.290569
                        ],
                        [
                            -3.638969,
                            53.288934
                        ],
                        [
                            -3.599659,
                            53.287574
                        ],
                        [
                            -3.599213,
                            53.287475
                        ],
                        [
                            -3.598915,
                            53.287342
                        ],
                        [
                            -3.586787,
                            53.284912
                        ],
                        [
                            -3.586386,
                            53.284921
                        ],
                        [
                            -3.572005,
                            53.284135
                        ],
                        [
                            -3.570428,
                            53.283951
                        ],
                        [
                            -3.562857,
                            53.279555
                        ],
                        [
                            -3.540039,
                            53.273422
                        ],
                        [
                            -3.520048,
                            53.269579
                        ],
                        [
                            -3.412484,
                            53.262773
                        ],
                        [
                            -3.408885,
                            53.260915
                        ],
                        [
                            -3.405713,
                            53.262437
                        ],
                        [
                            -3.389073,
                            53.264633
                        ],
                        [
                            -3.388429,
                            53.264732
                        ],
                        [
                            -3.384685,
                            53.265234
                        ],
                        [
                            -3.383313,
                            53.265335
                        ],
                        [
                            -3.340881,
                            53.266013
                        ],
                        [
                            -3.332726,
                            53.265989
                        ],
                        [
                            -3.285731,
                            53.259024
                        ],
                        [
                            -3.26678,
                            53.255181
                        ],
                        [
                            -3.260226,
                            53.253601
                        ],
                        [
                            -3.204145,
                            53.240549
                        ],
                        [
                            -3.198415,
                            53.242096
                        ],
                        [
                            -3.196564,
                            53.241117
                        ],
                        [
                            -3.193486,
                            53.24417
                        ],
                        [
                            -3.192777,
                            53.244506
                        ],
                        [
                            -3.191417,
                            53.243431
                        ],
                        [
                            -3.147506,
                            53.245276
                        ],
                        [
                            -3.147475,
                            53.245255
                        ],
                        [
                            -3.144725,
                            53.246219
                        ],
                        [
                            -3.139861,
                            53.245263
                        ],
                        [
                            -3.137633,
                            53.247309
                        ],
                        [
                            -3.133765,
                            53.249696
                        ],
                        [
                            -3.133107,
                            53.24926
                        ],
                        [
                            -3.114329,
                            53.23924
                        ],
                        [
                            -3.112439,
                            53.238643
                        ],
                        [
                            -3.104017,
                            53.23623
                        ],
                        [
                            -3.091385,
                            53.231865
                        ],
                        [
                            -3.087287,
                            53.230154
                        ],
                        [
                            -3.060642,
                            53.220562
                        ],
                        [
                            -3.059728,
                            53.221117
                        ],
                        [
                            -3.059499,
                            53.221333
                        ],
                        [
                            -3.059238,
                            53.220997
                        ],
                        [
                            -3.051388,
                            53.220756
                        ],
                        [
                            -3.036979,
                            53.216406
                        ],
                        [
                            -3.034676,
                            53.215699
                        ],
                        [
                            -3.034595,
                            53.215776
                        ],
                        [
                            -3.034263,
                            53.216236
                        ],
                        [
                            -3.020136,
                            53.223679
                        ],
                        [
                            -3.001161,
                            53.222893
                        ],
                        [
                            -2.926211,
                            53.206427
                        ],
                        [
                            -2.90343,
                            53.198702
                        ],
                        [
                            -2.901511,
                            53.19796
                        ],
                        [
                            -2.899256,
                            53.196538
                        ],
                        [
                            -2.897962,
                            53.195986
                        ],
                        [
                            -2.897743,
                            53.195998
                        ],
                        [
                            -2.897587,
                            53.195734
                        ],
                        [
                            -2.8945,
                            53.194192
                        ],
                        [
                            -2.893525,
                            53.1943
                        ],
                        [
                            -2.893355,
                            53.193778
                        ],
                        [
                            -2.893278,
                            53.193795
                        ],
                        [
                            -2.893085,
                            53.193855
                        ],
                        [
                            -2.890356,
                            53.193975
                        ]
                    ],
                    "type": "LineString"
                }
            }
        ],
        "waypoints": [
            {
                "distance": 59.472,
                "name": "Tintern Abbey",
                "location": [
                    -2.677815,
                    51.697084
                ]
            },
            {
                "distance": 10.301,
                "name": "Transporter Bridge",
                "location": [
                    -2.987333,
                    51.571209
                ]
            },
            {
                "distance": 9.818,
                "name": "Cardiff Castle",
                "location": [
                    -3.181046,
                    51.482255
                ]
            },
            {
                "distance": 2.171,
                "name": "Rest Bay Beach",
                "location": [
                    -3.723539,
                    51.489119
                ]
            },
            {
                "distance": 4.71,
                "name": "Mumbles Pier",
                "location": [
                    -3.977779,
                    51.569108
                ]
            },
            {
                "distance": 57.954,
                "name": "Fall Bay",
                "location": [
                    -4.291874,
                    51.563078
                ]
            },
            {
                "distance": 23.132,
                "name": "Parc y Scarlets",
                "location": [
                    -4.128446,
                    51.678217
                ]
            },
            {
                "distance": 3.107,
                "name": "Kidwelly Castel",
                "location": [
                    -4.305814,
                    51.739057
                ]
            },
            {
                "distance": 222.091,
                "name": "St Catherines Island",
                "location": [
                    -4.693686,
                    51.672046
                ]
            },
            {
                "distance": 210.807,
                "name": "Barafundle Bay",
                "location": [
                    -4.903263,
                    51.619624
                ]
            },
            {
                "distance": 654.829,
                "name": "Stack Rock Fort",
                "location": [
                    -5.093473,
                    51.696745
                ]
            },
            {
                "distance": 22.981,
                "name": "St Davids Cathedral",
                "location": [
                    -5.26807,
                    51.88212
                ]
            },
            {
                "distance": 23.26,
                "name": "Strumble Head Lighthouse",
                "location": [
                    -5.073484,
                    52.029662
                ]
            },
            {
                "distance": 9.708,
                "name": "Cardigan Castle",
                "location": [
                    -4.660522,
                    52.081967
                ]
            },
            {
                "distance": 32.942,
                "name": "Plas Tan y Bwlch",
                "location": [
                    -4.061308,
                    52.409038
                ]
            },
            {
                "distance": 1.599,
                "name": "Round House",
                "location": [
                    -4.052533,
                    52.719312
                ]
            },
            {
                "distance": 6.641,
                "name": "Harlech Castle",
                "location": [
                    -4.108895,
                    52.85996
                ]
            },
            {
                "distance": 17.102,
                "name": "Nant Gwrtheyrn",
                "location": [
                    -4.458264,
                    52.975332
                ]
            },
            {
                "distance": 0.269,
                "name": "Bedd Gelert ",
                "location": [
                    -4.10283,
                    53.011971
                ]
            },
            {
                "distance": 9.719,
                "name": "Caernarfon Castle",
                "location": [
                    -4.276922,
                    53.139061
                ]
            },
            {
                "distance": 83.631,
                "name": "Beaumaris Castle",
                "location": [
                    -4.08984,
                    53.264125
                ]
            },
            {
                "distance": 39.231,
                "name": "Conwy Castle",
                "location": [
                    -3.825355,
                    53.280387
                ]
            },
            {
                "distance": 4.123,
                "name": "City Walls",
                "location": [
                    -2.890356,
                    53.193975
                ]
            }
        ],
        "code": "Ok",
        "uuid": "aAm8reXDklP0n6UJA4XbTPZcGyOz4A9_iKBdi1gX0uyxtTNeborCGg=="
    }

    return directions;
}

export function updatePersonIcon(index)
{
    personMarker.setLngLat(directionAPI().routes[0].geometry.coordinates[index]);
}