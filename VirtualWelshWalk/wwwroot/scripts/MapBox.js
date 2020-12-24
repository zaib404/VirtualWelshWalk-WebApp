include('https://api.mapbox.com/mapbox-gl-js/v2.0.0/mapbox-gl.js');


function initialize()
{
    mapboxgl.accessToken = 'pk.eyJ1IjoiemFpYjk3IiwiYSI6ImNrajAzODdncTJuMWIycXNjOG1qZ2lnenkifQ.pyZXLfrmzU-f-FhoHMBd5Q';
    var map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v11',
        center: [-122.486052, 37.830348],
        zoom: 15
    })
    return map;
}