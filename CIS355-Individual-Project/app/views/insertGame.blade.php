@extends('layout')								
@section('content')								
  <h1>Insert Game</h1>
  
  {{ HTML::ul($errors->all(), array('class'=>'errors')) }}
  
  {{ Form::open() }}		
  
  <p>
    {{ Form::label('Session ID: ') }}
    {{ Form::selectRange('session_id', 1, 100) }}
  </p>
  <p>
  {{ Form::label('Score: ') }}						
  {{ Form::selectRange('score', 0, 300) }}
  </p>

  {{ Form::submit() }}
  {{ Form::close() }}
  
@stop