@extends('layout')								
@section('content')								
  <h1>Update Game</h1>
  
  {{ HTML::ul($errors->all(), array('class'=>'errors')) }}
  
  {{ Form::open(array('method' => 'PUT')) }}		
  
  {{ Form::hidden('id', $id) }}
  <p>
    {{ Form::label('Session ID: ') }}
    {{ Form::selectRange('session_id', 1, 100, $sessionId) }}
  </p>
  <p>
  {{ Form::label('Score: ') }}						
  {{ Form::selectRange('score', 0, 300, $score) }}
  </p>

  {{ Form::submit() }}
  {{ Form::close() }}
  
@stop