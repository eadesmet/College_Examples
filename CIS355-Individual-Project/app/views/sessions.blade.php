@extends('layout')
@section('content')
  <h1>Sessions.</h1>
<!--The Sessions Page
    Shows the content in the generic "layout" blade file
    Then shows the Session table corresponding to which
    league was selected
-->

  
  <p>The list of the Sessions is below:</p>
  <p>Each league has multiple sessions</p>

  <table border="1" style="width:50%">
      <tr>
          <td>Session ID</td>
          <td>League ID</td>
          <td>Leage Name</td>
          <td>Date</td>
          <td>Options</td>
      </tr>
    @foreach($sessions as $session)					
    <!--if( $session->league_id = leagueId) -->
	<tr>
	  <td>{{ $session->id }}</td>
	  <td>{{ $session->league_id }}</td>					
	  <td>{{ $session->league_name }}</td>
	  <td>{{ $session->date }}</td>

	  <td>
	    <form>
          <input type="button" value="View" onclick="window.location='/Bowling/public/games/{{ $session->id }}'"/>
          <input type="button" value="Update"  onclick="window.location='/Bowling/public/updateSession/{{ $session->id }}/{{ $session->league_id }}/{{ $session->league_name }}/{{ $session->date }}'"/>
          <input type="button" value="Delete" onclick="window.location='/Bowling/public/deleteSession/{{ $session->id }}'"/>
        </form>
	  </td>
	</tr>
	<!--endif -->
	@endforeach
  </table>
  <h3><a href='./insertSession'>Insert New Session</a></h3>

@stop