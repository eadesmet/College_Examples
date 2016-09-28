@extends('layout')								
@section('content')								
  <h1>Update Session</h1>
  
  {{ HTML::ul($errors->all(), array('class'=>'errors')) }}
  
  {{ Form::open(array('method' => 'PUT')) }}			
  
  {{ Form::hidden('id', $id) }}
  
  <p>
      {{ Form::label('League ID: ') }}
      {{ Form::selectRange('league_id', 1, 100) }}
  </p>
  <p>
      <!--league id? -->
  {{ Form::label('League Name: ') }}						
  {{ Form::text('league_name', $leagueName) }}
  </p>
  <p>
  {{ Form::label('Date: ') }}
  {{ Form::text('date', $date) }}
  </p>
  {{ Form::submit() }}
  {{ Form::close() }}
  
@stop