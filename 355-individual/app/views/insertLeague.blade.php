@extends('layout')								
@section('content')								
  <h1>Insert League</h1>
  
  {{ HTML::ul($errors->all(), array('class'=>'errors')) }}
  
  {{ Form::open() }}							
  <p>
  {{ Form::label('Name: ') }}						
  {{ Form::text('name') }}
  </p>
  <p>
  {{ Form::label('Date: ') }}
  {{ Form::text('date') }}
  </p>
  {{ Form::submit() }}
  {{ Form::close() }}
  
@stop