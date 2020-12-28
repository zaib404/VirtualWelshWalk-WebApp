import 'https://api.mapbox.com/mapbox-gl-js/v2.0.0/mapbox-gl.js';

mapboxgl.accessToken = 'pk.eyJ1IjoiemFpYjk3IiwiYSI6ImNrajAzODdncTJuMWIycXNjOG1qZ2lnenkifQ.pyZXLfrmzU-f-FhoHMBd5Q';

export function initialize()
{
    var map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v11'
    });

    return map;
}