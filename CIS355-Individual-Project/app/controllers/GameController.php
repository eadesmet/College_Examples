<?php

class GameController extends BaseController {

	public function showGames()
	{
        $games = Game::all();
        
        return View::make('games', array('games' => $games));
	}
	
	public function showGamesById($id)
	{
	    $games = DB::table('games')
                ->where('session_id', '=', $id)
                ->get();
	                    
        return View::make('games', array('games' => $games));
	}
	
	public function insertGame()
	{
	    return View::make('insertGame');
	}
	
	public function postInsertGame()
	{
        $input = Input::all();
    
        $rules = array(
            'session_id' => 'required',
            'score' => 'required'
        );
        
        $validator = Validator::make($input, $rules);
        
        if($validator->fails()) {					
    	   return Redirect::to('insertGame')->withErrors($validator)->withInput();
        }
        
        //DB::table('leagues')->insert($input);
        
        $inputSessionID = Input::get('session_id');
        $inputScore = Input::get('score');
        
        //$testing = Input::get('name');
        
        DB::table('games')->insert(array('session_id' => $inputSessionID,
                                      'score' => $inputScore));
        
        //return $testing;
        //return View::make('home');
        return Redirect::to('games')->with('message', 'Created new Record in Sessions table');
	}
	
	public function updateGame($id, $sessionId, $score)
	{
	    	    return View::make('updateGame')->with('id', $id)
	                                     ->with('sessionId', $sessionId)
	                                     ->with('score', $score);
	}
	
	public function putUpdateGame()
	{
	    $input = Input::all();
	    
	    $rules = array(
            'sessionId' => 'required',
            'score' => 'required'
        );
        
        $validator = Validator::make($input, $rules);
        
    /*    if($validator->fails()) {					
    	   return Redirect::to('updateGame')->withErrors($validator)->withInput();
        } */
        
        $id = Input::get('id');
        $sessionId = Input::get('sessionId');
        $score = Input::get('score');
        
        DB::table('games')->where('id', '=', $id)
                            ->update(array(//'session_id' => $sessionId,
                                            'score' => $score));
	    
	    return Redirect::to('games')->with('message', 'Updated Record in Games table');
	}
	
	public function deleteGame($id)
	{
	    return View::make('deleteGame')->with('id', $id);
	}
	
	public function postDeleteGame($id)
	{
	    DB::table('games')->where('id', '=', $id)
	                        ->delete();
	                        
	   return Redirect::to('games')->with('message', 'Deleted ID '.$id.' from Games table');
	}
	
}