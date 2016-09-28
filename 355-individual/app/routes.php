<?php

/*
|--------------------------------------------------------------------------
| Application Routes
|--------------------------------------------------------------------------
|
| Here is where you can register all of the routes for an application.
| It's a breeze. Simply tell Laravel the URIs it should respond to
| and give it the Closure to execute when that URI is requested.
|
*/

//***********HOME PAGE***********
Route::get('/', function()
{
    //returns a rendered template from the home.blade.php file
    return View::make('home');
	/*return 'Home Page. If you are seeing this, then I am still working on it. I
	*am doing my individual project in laravel (and c9) and making good progress
	so far';*/
});

//***********LEAGUES PAGE***********
Route::get('leagues', 'LeagueController@showLeagues');

Route::get('leagues/{id}', 'LeagueController@showLeagueId'); //just testing

//Route::post('leagues', 'LeagueController@insertLeague'); //just testing

Route::get('insertLeague', 'LeagueController@insertLeague'); //pass id here
Route::post('insertLeague', 'LeagueController@postInsertLeague');

Route::get('updateLeague/{id}/{name}/{date}', 'LeagueController@updateLeague');
Route::put('updateLeague/{id}/{name}/{date}', 'LeagueController@putUpdateLeague');

Route::get('deleteLeague/{id}', 'LeagueController@deleteLeague');
Route::post('deleteLeague/{id}', 'LeagueController@postDeleteLeague');


//***********SESSIONS PAGE***********
Route::get('sessions', 'SessionController@showSessions');
Route::get('sessions/{id}', 'SessionController@showSessionsById');

Route::get('insertSession', 'SessionController@insertSession');
Route::post('insertSession', 'SessionController@postInsertSession');

Route::get('updateSession/{id}/{league_id}/{league_name}/{date}', 'SessionController@updateSession');
Route::put('updateSession/{id}/{league_id}/{league_name}/{date}', 'SessionController@putUpdateSession');

Route::get('deleteSession/{id}', 'SessionController@deleteSession');
Route::post('deleteSession/{id}', 'SessionController@postDeleteSession');


/*{
    $sessions = SessionModel::all(); //needs model file
    //return $sessionsValues;
    return View::make('sessions', array('sessions' => $sessions));
});*/

//***********GAMES PAGE***********
Route::get('games', 'GameController@showGames');
Route::get('games/{id}', 'GameController@showGamesById');

Route::get('insertGame', 'GameController@insertGame');
Route::post('insertGame', 'GameController@postInsertGame');

Route::get('updateGame/{id}/{session_id}/{score}', 'GameController@updateGame');
Route::put('updateGame/{id}/{session_id}/{score}', 'GameController@putUpdateGame');

Route::get('deleteGame/{id}', 'GameController@deleteGame');
Route::post('deleteGame/{id}', 'GameController@postDeleteGame');

/*{
    $games = Game::all();
    
    return View::make('games', array('games' => $games));
});*/


//***********INSERT SESSION PAGE****************


//***********POST INSERT SESSION***********


//***********INSERT GAME PAGE***********


//***********POST INSERT GAME***********
