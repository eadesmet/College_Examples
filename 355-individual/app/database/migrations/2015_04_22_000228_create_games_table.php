<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateGamesTable extends Migration {

	/**
	 * Run the migrations.
	 *
	 * @return void
	 */
	public function up()
	{
		//
		Schema::create('games', function($table)
		{
			$table->increments('id');
			$table->integer('session_id')->unsigned();
			$table->foreign('session_id')->references('id')->on('sessions');
			$table->integer('score');//->unsigned();
			$table->timestamps();
		}); 
	}

	/**
	 * Reverse the migrations.
	 *
	 * @return void
	 */
	public function down()
	{
		//
	}

}
