@extends('layout')
@section('content')
  <h1>Games.</h1>

  <p>The list of the Games is below:</p>
  <p>Each session has 3 games</p>

  <table border="1" style="width:50%">
      <tr>
          <td>Game ID</td>
          <td>Session ID</td>
          <td>Score</td>
          <td>Options</td>
      </tr>
    @foreach($games as $game)					
	<tr>
	  <td>{{ $game->id }}</td>
	  <td>{{ $game->session_id }}</td>					
	  <td>{{ $game->score }}</td>

	  <td>
	    <form>
          <!-- <input type="button" value="View" name='$session->id'/> -->
          <!-- need a view button for games? -->
          <input type="button" value="Update"  onclick="window.location='/Bowling/public/updateGame/{{ $game->id }}/{{ $game->session_id }}/{{ $game->score }}'"/>
          <input type="button" value="Delete" onclick="window.location='/Bowling/public/deleteGame/{{ $game->id }}'"/>
        </form>
	  </td>
	</tr>
	@endforeach
  </table>
  <h3><a href='./insertGame'>Insert New Game</a></h3>

@stop