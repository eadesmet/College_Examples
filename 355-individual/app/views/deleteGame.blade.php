@extends('layout')
@section('content')
<h1>Are you sure you want to Delete this Game?</h1>

{{ Game::find($id) }}
</br>
{{ Form::open() }}
{{ Form::submit() }}
{{ Form::close() }}

@stop