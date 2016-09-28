@extends('layout')								
@section('content')								
  <h1>Insert Sesison</h1>
  
  {{ HTML::ul($errors->all(), array('class'=>'errors')) }}
  
  {{ Form::open() }}							
  <p>
      {{ Form::label('League ID: ') }}
      {{ Form::selectRange('league_id', 1, 100) }}
  </p>
  <p>
      <!--league id? -->
  {{ Form::label('League Name: ') }}						
  {{ Form::text('league_name') }}
  </p>
  <p>
  {{ Form::label('Date: ') }}
  {{ Form::text('date') }}
  </p>
  {{ Form::submit() }}
  {{ Form::close() }}
  
@stop