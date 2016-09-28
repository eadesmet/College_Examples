@extends('layout')								
@section('content')								
  <h1>Update League</h1>
  
  {{ HTML::ul($errors->all(), array('class'=>'errors')) }}
  
  {{ Form::open(array('method' => 'PUT')) }}	
  
  {{ Form::hidden('id', $id) }}
  <p>
  {{ Form::label('Name: ') }}						
  {{ Form::text('name', $name) }}
  </p>
  <p>
  {{ Form::label('Date: ') }}
  {{ Form::text('date', $date) }}
  </p>
  
  <!-- Form::hidden('id', $league->id) -->
  
  
  {{ Form::submit() }}
  {{ Form::close() }}
  
@stop