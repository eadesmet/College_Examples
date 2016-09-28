@extends('layout')
@section('content')
  <h1>Leagues.</h1>
  <p>The list of the Leagues is below:</p>

  <table border="1" style="width:50%">
      <tr>
          <td>League ID</td>
          <td>League Name</td>
          <td>Leage Date</td>
          <td>Options</td>
      </tr>
    @foreach($leagues as $league)					
	<tr>
	  <td>{{ $league->id }}</td>
	  <td>{{ $league->name }}</td>					
	  <td>{{ $league->date }}</td>
	  <!--<td>{{ Form::button('View') }}</td>-->
	  <!-- pass in the league id!! -->
	  <td>
	    <!-- Form::open(array('action' => array('LeagueController@showOptions', $league->id))) 
	    Form::open(array('action' => array('FooController@method', $parameter)));
	     Form::close() --> 
	    <form>
          <input type="button" value="View" onclick="window.location='./sessions/{{ $league->id }}'"/>
          <input type="button" value="Update" onclick="window.location='./updateLeague/{{ $league->id }}/{{ $league->name }}/{{ $league->date }}'"/>
          <input type="button" value="Delete" onclick="window.location='./deleteLeague/{{ $league->id }}'"/>
          <input type="hidden" value='{{ $league->id }}' name="passedId"/>
        </form> 
      <!--<a href='./sessions/{{ $league->id }}'> View</a>
      <a href='./updateLeague/{{ $league->id }}/{{ $league->name }}/{{ $league->date }}'>Update</a> -->
	  </td>
	</tr>
	@endforeach
  </table>
  <h3><a href='./insertLeague'>Insert New League</a></h3>
@stop