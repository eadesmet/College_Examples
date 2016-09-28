@extends('layout')
@section('content')
<h1>Are you sure you want to Delete this League?</h1>

{{ League::find($id) }}
</br>
{{ Form::open() }}
{{ Form::submit() }}
{{ Form::close() }}

@stop