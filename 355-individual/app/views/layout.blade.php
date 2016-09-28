<!doctype html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>CIS355 Individual Project - Bowling Leagues</title>
</head>
<body>
  <ul>
    <li><a href="/Bowling/public/">Home</a></li>
    <li><a href="/Bowling/public/leagues">Leagues</a></li>
    <li><a href="/Bowling/public/sessions">Sessions</a></li> <!-- not in yet -->
    <li><a href="/Bowling/public/games">Games</a></li>
  </ul>
  
  @if(Session::has('message'))
    <p style="color: green;">{{ Session::get('message') }}</p>
  @endif

  @yield('content')
  
  </br></br>
  Eric DeSmet, {{ date('Y M D') }}						
</body>
</html>