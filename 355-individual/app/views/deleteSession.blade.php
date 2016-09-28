@extends('layout')
@section('content')
<h1>Are you sure you want to Delete this Session?</h1>

{{ SessionModel::find($id) }}
</br>
{{ Form::open() }}
{{ Form::submit() }}
{{ Form::close() }}

@stop