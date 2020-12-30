(function() {
    function toPascalCase(obj) {
        const entries = Object.entries(obj);
        return Object.fromEntries(entries.map(e => [firstUpper(e[0]), e[1]]));
    }

    function firstUpper(s) {
        return s.substr(0,1).toUpperCase() + s.substr(1);
    }

    function getMovesForFen(fen) {
        const chess = new Chess(fen);
        return chess.moves().map(toPascalCase);
    }
    
    function getLegalMoves(positions, colorToMove, square) {
        const chess = new Chess(`8/8/8/8/8/8/8/8 ${colorToMove} - - 0 1`);
        for (const p of positions) {
            const [piece, square] = p;
            chess.put(piece, square);
        }
        return chess.moves({ square }).map(toPascalCase);
    }
    
    window.chess_js = {
        getMovesForFen,
        getLegalMoves
    };
})();
