<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateSessionsTable extends Migration {

	/**
	 * Run the migrations.
	 *
	 * @return void
	 */
	public function up()
	{
		
		//DB::query('alter table sessions modify league_id HERERERER');
		
		Schema::create('sessions', function($table)
		{
			$table->increments('id');
			//$table->integer('league_id');
			//$table->text('league_name');
			$table->integer('league_id')->unsigned();
			$table->foreign('league_id')->references('id')->on('leagues');
			$table->text('league_name');//->unsigned();
			//$table->foreign('league_name')->references('name')->on('leagues');
			$table->text('date');
			//timestamps?
			$table->timestamps();
			
			//STILL HAVE TO ALTER THEM TO FOREIGN KEYS
			
		}); 
		//
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
