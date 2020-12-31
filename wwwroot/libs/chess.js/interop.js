(function() {
    function getLegalMoves(positions, colorToMove, square) {
        const chess = new Chess(`8/8/8/8/8/8/8/8 ${colorToMove} - - 0 1`);
        for (const p of positions) {
            const [piece, square] = p;
            chess.put(piece, square);
        }
        return chess.moves({ square, verbose: true  });
    }
    
    window.chess_js = {
        getLegalMoves
    };
})();
